using LudicWorlds;

using UnityEngine;

public class LoadDecoderState : SentisWhisperState
{

    public LoadDecoderState(IStateMachine<WhisperStateID> stateMachine) : base(stateMachine, WhisperStateID.LoadDecoder, WhisperStateID.LoadEncoder)
    {
        
    }

    public override void Enter()
    {
        //Debug.Log("-> LoadDecoderState::Enter()");
        DebugPanel.SetStatus("LoadDecoder");
        stage = 0;
    }

    public override void Update()
    {
        switch(stage)
        {
            case 0:
                LoadDecoder();
                stage = 1;
                break;
            default:
                stateMachine.SetState( nextStateId );
                break;
        }      
    }

    private void LoadDecoder() 
    {
        Unity.InferenceEngine.Model decoder = Unity.InferenceEngine.ModelLoader.Load(whisper.decoderAsset);

        // Define the functional graph of the model.
        var graph = new Unity.InferenceEngine.FunctionalGraph();

        // Set the inputs of the graph from the original model inputs and return an array of functional tensors
        var inputs = graph.AddInputs(decoder);

        // Apply the model forward function to the inputs to get the source model functional outputs.
        // Sentis will destructively change the loaded source model. To avoid this at the expense of
        // higher memory usage and compile time, use the Functional.ForwardWithCopy method.
        Unity.InferenceEngine.FunctionalTensor[] outputs = Unity.InferenceEngine.Functional.Forward(decoder, inputs);

        // Calculate the argMax of the first output with the functional API.
        Unity.InferenceEngine.FunctionalTensor argmaxOutput = Unity.InferenceEngine.Functional.ArgMax(outputs[0],2);

        // Build the model from the graph using the `Compile` method with the desired outputs.
        Unity.InferenceEngine.Model decoderWithArgMax = graph.Compile(argmaxOutput);

        whisper.DecoderEngine = new Unity.InferenceEngine.Worker(decoderWithArgMax, backend);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
