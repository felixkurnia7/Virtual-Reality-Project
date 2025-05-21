using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIdle : Node
{
    //private bool _isIdle = false;
    private readonly NPC_AI _npc;

    public CheckIdle(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }

    public override NodeState Evaluate()
    {
        if (_npc.notIdle == true)
        {
            Debug.Log("not idle is true");
            // Apakah transisi animasi disini?
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            Debug.Log("not idle is false");
            state = NodeState.FAILURE;
            return state;
        }
    }
}
