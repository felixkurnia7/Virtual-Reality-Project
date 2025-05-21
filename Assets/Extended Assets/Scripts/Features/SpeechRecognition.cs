using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using HuggingFace.API;
using System;

public class SpeechRecognition : MonoBehaviour
{

    public Action<string> CheckWMP;
    public Action StartTimer;
    public Action StopTimer;
    public Action<float[]> CheckVolume;
    public Action<string> CheckFillerWord;

    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
//[SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int bufferSize;
    [SerializeField] private StringValue textSO;
    [SerializeField] private int sampleSize;

    private AudioClip clip;
    private byte[] bytes;
    private float[] samples;

    public string selectedMicrophone;

    private void Start()
    {
        ResetText();
        // Automatically set to the first available microphone
        if (Microphone.devices.Length > 0)
        {
            selectedMicrophone = Microphone.devices[0];
        }
    }

    private void Update()
    {
        
    }

    //public void StartRecording()
    //{
    //    clip = Microphone.Start(null, false, 60, 44100);
    //    //recording = true;
    //}

    //public void StopRecording()
    //{
    //    var position = Microphone.GetPosition(null);
    //    Microphone.End(null);
    //    var samples = new float[position * clip.channels];
    //    clip.GetData(samples, 0);
    //    bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
    //    CheckVolume(samples);
    //    Debug.Log("Encoding...");
    //    SendRecording();
    //    File.WriteAllBytes(Application.dataPath + "/test.wav", bytes);
    //}

    //private void SendRecording()
    //{
    //    HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
    //        textSO.text += " " + response;
    //        CheckWMP?.Invoke(response);
    //        CheckFillerWord?.Invoke(response);
    //    }, error => {
    //        Debug.Log(error);
    //    });
    //}

    public void ResetText()
    {
        textSO.ResetText();
    }

    //private byte[] encodeaswav(float[] samples, int frequency, int channels)
    //{
    //    using (var memorystream = new memorystream(44 + samples.length * 2))
    //    {
    //        using (var writer = new binarywriter(memorystream))
    //        {
    //            writer.write("riff".tochararray());
    //            writer.write(36 + samples.length * 2);
    //            writer.write("wave".tochararray());
    //            writer.write("fmt ".tochararray());
    //            writer.write(16);
    //            writer.write((ushort)1);
    //            writer.write((ushort)channels);
    //            writer.write(frequency);
    //            writer.write(frequency * channels * 2);
    //            writer.write((ushort)(channels * 2));
    //            writer.write((ushort)16);
    //            writer.write("data".tochararray());
    //            writer.write(samples.length * 2);

    //            foreach (var sample in samples)
    //            {
    //                writer.write((short)(sample * short.maxvalue));
    //            }
    //        }
    //        return memorystream.toarray();
    //    }
    //}

    // -------------------------------------------------------------------------------

    public void StartRecording()
    {
        clip = Microphone.Start(null, false, 20, 44100);
        //StartTimer?.Invoke();
    }

    public void StopRecording()
    {
        //StopTimer?.Invoke();
        var position = Microphone.GetPosition(null);
        int offset = (position - bufferSize) % clip.samples;
        Microphone.End(null);
        samples = new float[clip.samples * clip.channels];
        //clip.GetData(samples, 0);
        try
        {
            clip.GetData(samples, offset);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error getting audio data: {ex.Message}");
        }
        //SaveWavFile(savePath, clip);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        CheckVolume(samples);
        //recording = false;
        Debug.Log("Encoding...");
        File.WriteAllBytes(Application.dataPath + "/test.wav", bytes);


        SendRecording();

    }

    private void SendRecording()
    {
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response =>
        {
            Debug.Log(response);
            //textSO.text += response;
            textSO.text += " " + response;
            //text.color = Color.white;
            //text.text = textSO.text;
            //startButton.interactable = true;
            CheckWMP?.Invoke(response);
            CheckFillerWord?.Invoke(response);
        }, error =>
        {
            Debug.Log(error);
            //startButton.interactable = true;
        });
    }

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using var memoryStream = new MemoryStream(44 + samples.Length * 2);
        using (BinaryWriter writer = new(memoryStream))
        {
            writer.Write("RIFF".ToCharArray());
            writer.Write(36 + samples.Length * 2);
            writer.Write("WAVE".ToCharArray());
            writer.Write("fmt ".ToCharArray());
            writer.Write(16);
            writer.Write((ushort)1);
            writer.Write((ushort)channels);
            writer.Write(frequency);
            writer.Write(frequency * channels * 2);
            writer.Write((ushort)(channels * 2));
            writer.Write((ushort)16);
            writer.Write("data".ToCharArray());
            writer.Write(samples.Length * 2);

            foreach (var sample in samples)
            {
                writer.Write((short)(sample * short.MaxValue));
            }
        }
        return memoryStream.ToArray();
    }

    public void CallData(string text)
    {
        textSO.text += " " + text;
        CheckWMP?.Invoke(text);
        CheckFillerWord?.Invoke(text);
    }

}
