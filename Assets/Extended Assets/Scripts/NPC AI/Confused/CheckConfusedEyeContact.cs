using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckConfusedEyeContact : Node
{
    private readonly NPC _npc;
    private readonly float eyeContactThreshold;

    public CheckConfusedEyeContact(NPC npc, float eyeContactConfused)
    {
        _npc = npc;
        eyeContactThreshold = eyeContactConfused;
    }

    public override NodeState Evaluate()
    {
        if (_npc.stare < eyeContactThreshold)
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
