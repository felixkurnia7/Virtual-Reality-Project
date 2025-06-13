using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInterestedWPM : Node
{
    private readonly MicRecorder _micRecorder;
    private readonly float wpmThreshold;

    public CheckInterestedWPM(MicRecorder micRecorder, float wpmInterested)
    {
        _micRecorder = micRecorder;
        wpmThreshold = wpmInterested;
    }

    public override NodeState Evaluate()
    {
        if (_micRecorder.audioClipList.Count > wpmThreshold)
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
