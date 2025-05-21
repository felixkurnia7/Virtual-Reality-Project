using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInterestedEyeContact : Node
{
    private readonly NPC _npc;
    private readonly float eyeContactThreshold;
    public CheckInterestedEyeContact(NPC npc, float eyeContactInterested)
    {
        _npc = npc;
        eyeContactThreshold = eyeContactInterested;
    }

    public override NodeState Evaluate()
    {
        if (_npc.stare > eyeContactThreshold)
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
