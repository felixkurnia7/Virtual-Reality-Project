using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckListeningTimer : Node
{
    private readonly FloatValue _timer;
    private readonly NPC_AI _npc;
    private readonly float timeListeningThreshold;
    private readonly float timeIdleThreshold;

    public CheckListeningTimer(FloatValue timer, Transform transform, float timeIdle, float timeListening)
    {
        _timer = timer;
        _npc = transform.GetComponent<NPC_AI>();
        timeIdleThreshold = timeIdle;
        timeListeningThreshold = timeListening;
    }

    public override NodeState Evaluate()
    {
        // Jika timer lebih dari 5 menit maka akan masuk tree BORED / INTERESTED / CONFUSE
        if (_timer.value > timeListeningThreshold)
        {
            Debug.Log("timer value > 300f");
            _npc.notIdle = true;
            _npc.notListening = true;
            state = NodeState.SUCCESS;
            return state;
        }
        // Jika timer diantara 2 - 5 menit maka tetap listening
        else if (_timer.value > timeIdleThreshold && _timer.value < timeListeningThreshold)
        {
            Debug.Log("timer value > 120 dan < 300 ");
            state = NodeState.FAILURE;
            return state;
        }
        // Jika timer kurang dari 2 menit
        else
        {
            Debug.Log("timer value < 120f");
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
