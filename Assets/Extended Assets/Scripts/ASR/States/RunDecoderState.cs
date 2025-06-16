using LudicWorlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.InferenceEngine;
using UnityEngine;

public class RunDecoderState : SentisWhisperState
{
    const int END_OF_TEXT = 50257;
    const int START_OF_TRANSCRIPT = 50258;
    const int ENGLISH = 50259;
    const int INDONESIAN = 50275;
    const int GERMAN = 50261;
    const int FRENCH = 50265;
    const int TRANSCRIBE = 50359; //for speech-to-text in specified language
    const int TRANSLATE = 50358;  //for speech-to-text then translate to English
    const int NO_TIME_STAMPS = 50363;
    const int START_TIME = 50364;

    // This is how many tokens you want. It can be adjusted.
    const int maxTokens = 100;
    private int currentToken = 3;
    private int[] outputTokens = new int[maxTokens];
    private string outputString = "";

    Tensor<int> tokensPredictions;
    Tensor<int> cpuTokensPredictions;

    // Start is called before the first frame update
    public RunDecoderState(IStateMachine<WhisperStateID> stateMachine) : base(stateMachine, WhisperStateID.RunDecoder, WhisperStateID.Ready)
    {
    }

    public override void Enter()
    {
        Debug.Log("-> RunDecoderState::Enter()");
        DebugPanel.SetStatus("RunDecoder");
        stage = 0;

        outputTokens[0] = START_OF_TRANSCRIPT;
        outputTokens[1] = INDONESIAN;//INDONESIAN; //ENGLISH;// GERMAN;//FRENCH;
        outputTokens[2] = TRANSCRIBE; //TRANSLATE;//
        outputTokens[3] = NO_TIME_STAMPS;// START_TIME;//
        currentToken = 3;

        outputString = "";
    }


    public override void Update()
    {
        switch (stage)
        {
            case 0:
                if (currentToken < outputTokens.Length - 1)
                {
                    ExecuteDecoder();
                }
                break;
            case 1:
                Debug.Log("Check Next Audio Clip");
                CheckNextAudio();
                break;
            case 2:
                Debug.Log("This will process next Audio");
                //stage = 3;
                stateMachine.SetState(WhisperStateID.StartTranscription);
                break;
            default:
                //stateMachine.SetState(nextStateId);
                stateMachine.ClearStates();
                whisper.StartEngine();
                break;
        }
    }

    private void ExecuteDecoder()
    {
        using var tokensSoFar = new Tensor<int>(new TensorShape(1, outputTokens.Length), outputTokens);

        var inputs = new Dictionary<string, Tensor>
            {
                {"input_0", tokensSoFar },
                {"input_1", whisper.EncodedAudio }
            };

        whisper.DecoderEngine.Schedule(inputs.Values.ToArray());   //Execute(inputs);
        tokensPredictions = whisper.DecoderEngine.PeekOutput() as Tensor<int>;
        cpuTokensPredictions = tokensPredictions.ReadbackAndClone(); //CPU copy of the output tensor

        int ID = cpuTokensPredictions[currentToken];

        outputTokens[++currentToken] = ID;

        if (ID == END_OF_TEXT)
        {
            Debug.Log("*WHISPER*: " + outputString);

            if (whisper.textSO != null)
            {
                //whisper.SpeechText.color = new Color(1f, 0.6133823f, 0f);
                whisper.textSO.text += " " + outputString;
                whisper.CheckFillerWord?.Invoke(outputString);
            }
            else
            {
                Debug.LogError("-> RunDecoderState::Update() - SpeechText is NULL! :(");
            }
            stage = 1;
        }
        else if (ID >= whisper.Tokens.Length)
        {
            outputString += $"(time={(ID - START_TIME) * 0.02f})";
            Debug.Log(outputString);
        }
        else
        {
            outputString += GetUnicodeText(whisper.Tokens[ID]);
            Debug.Log("-> " + outputString);
        }
    }

    private void CheckNextAudio()
    {
        if (!whisper.audioClipQueue.Any())
        {
            Debug.Log("No audio clip on the list");
            whisper.audioClipQueue.Clear();
            whisper.AudioClipList.Clear();
            whisper.CheckWMP?.Invoke();
            stage = 3;
        }
        else
        {
            Debug.Log("There is an audio on the list");
            stage = 2;
        }

    }

     
    // Translates encoded special characters to Unicode
    string GetUnicodeText(string text)
    {
        var bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(ShiftCharacterDown(text));
        return Encoding.UTF8.GetString(bytes);
    }

    string ShiftCharacterDown(string text)
    {
        string outText = "";
        foreach (char letter in text)
        {
            outText += ((int)letter <= 256) ? letter :
                (char)whisper.WhiteSpaceCharacters[(int)(letter - 256)];
        }
        return outText;
    }

    public override void Exit()
    {
        tokensPredictions.Dispose();
        cpuTokensPredictions.Dispose();
        whisper.EncodedAudio.Dispose();

        GC.Collect(); //Garbage collection
        base.Exit();
    }
}