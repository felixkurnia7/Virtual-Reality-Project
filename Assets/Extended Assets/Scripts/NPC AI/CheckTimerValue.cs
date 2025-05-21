using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckTimerValue : Node
{
    private FloatValue _timer;

    public CheckTimerValue(FloatValue timer)
    {
        _timer = timer;
    }

    public override NodeState Evaluate()
    {
        if (_timer.value < 60f)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
