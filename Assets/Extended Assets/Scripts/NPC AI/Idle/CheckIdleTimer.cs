using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIdleTimer : Node
{
    private readonly FloatValue _timer;
    private readonly NPC_AI _npc;
    private readonly float timeThreshold;

    public CheckIdleTimer(FloatValue timer, Transform transform, float timeIdle)
    {
        _timer = timer;
        _npc = transform.GetComponent<NPC_AI>();
        timeThreshold = timeIdle;
    }

    public override NodeState Evaluate()
    {
        if (_timer.value > timeThreshold)
        {
            Debug.Log("timer value > 120f");
            _npc.notIdle = true;
            _npc.notListening = false;
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            Debug.Log("timer value < 120f");
            state = NodeState.FAILURE;
            return state;
        }

        //state = NodeState.FAILURE;
        //return state;
    }
}
