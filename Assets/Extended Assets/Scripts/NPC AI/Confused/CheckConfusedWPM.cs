using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckConfusedWPM : Node
{
    private readonly FloatValue _wpm;
    private readonly float wpmThreshold;

    public CheckConfusedWPM(FloatValue wpm, float wpmConfused)
    {
        _wpm = wpm;
        wpmThreshold = wpmConfused;
    }

    public override NodeState Evaluate()
    {
        if (_wpm.value < wpmThreshold)
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
