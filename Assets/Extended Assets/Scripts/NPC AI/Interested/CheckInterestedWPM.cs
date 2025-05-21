using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInterestedWPM : Node
{
    private readonly FloatValue _wpm;
    private readonly float wpmThreshold;

    public CheckInterestedWPM(FloatValue wpm, float wpmInterested)
    {
        _wpm = wpm;
        wpmThreshold = wpmInterested;
    }

    public override NodeState Evaluate()
    {
        if (_wpm.value > wpmThreshold)
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
