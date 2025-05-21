using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class SetNPCToInterested : Node
{
    private NPC_AI _npc;

    public SetNPCToInterested(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }
    public override NodeState Evaluate()
    {
        //_npc.isIdle = false;
        //_npc.isInterested = true;
        //_npc.isBored = false;

        state = NodeState.RUNNING;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
