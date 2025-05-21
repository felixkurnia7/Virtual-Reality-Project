using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckListening : Node
{
    private readonly NPC_AI _npc;

    public CheckListening(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }

    public override NodeState Evaluate()
    {
        if (_npc.notListening == true)
        {
            Debug.Log("not listening is true");
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            Debug.Log("not listening is false");
            state = NodeState.FAILURE;
            return state;
        }
    }
}
