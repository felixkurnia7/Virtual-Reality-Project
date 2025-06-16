using LudicWorlds;

using UnityEngine;
using System.Collections;


public class RunSpectroState : SentisWhisperState
{
    private Unity.InferenceEngine.Tensor<float> spectroOutput;

    // Start is called before the first frame update
    public RunSpectroState(IStateMachine<WhisperStateID> stateMachine) : base(stateMachine, WhisperStateID.RunSpectro, WhisperStateID.RunEncoder)
    {
    }

    public override void Enter()
    {
        Debug.Log("-> RunSpectroState::Enter()");
        DebugPanel.SetStatus("RunSpectro");
        stage = 0;
        RunSpectro(); //we will do the inference in 1 frame
    }
 
    public override void Update()
    {
        stateMachine.SetState(nextStateId);
    }
       
    private void RunSpectro()
    { //in one go...
        using var input = new Unity.InferenceEngine.Tensor<float>(new Unity.InferenceEngine.TensorShape(1, whisper.NumSamples), whisper.Data);
        whisper.SpectroEngine.Schedule(input);
        spectroOutput = whisper.SpectroEngine.PeekOutput() as Unity.InferenceEngine.Tensor<float>;
        whisper.SpectroOutput = spectroOutput.ReadbackAndClone(); //CPU copy of the output tensor
        
    }

    public override void Exit()
    {
        spectroOutput.Dispose();
        base.Exit();
    }
}