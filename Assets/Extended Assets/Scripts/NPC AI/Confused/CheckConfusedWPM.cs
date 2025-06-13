using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckConfusedWPM : Node
{
    private readonly MicRecorder _micRecorder;
    private readonly float wpmThreshold;

    public CheckConfusedWPM(MicRecorder micRecorder, float wpmConfused)
    {
        _micRecorder = micRecorder;
        wpmThreshold = wpmConfused;
    }

    public override NodeState Evaluate()
    {
        if (_micRecorder.audioClipList.Count < wpmThreshold)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }
    }
}
