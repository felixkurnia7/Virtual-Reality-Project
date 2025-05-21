using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class SetNPCToIdle : Node
{
    private NPC_AI _npc;

    public SetNPCToIdle(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }
    public override NodeState Evaluate()
    {
        //_npc.isIdle = true;
        //_npc.isInterested = false;
        //_npc.isBored = false;

        state = NodeState.RUNNING;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
