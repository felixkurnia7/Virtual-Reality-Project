using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBoredTimer : Node
{
    private readonly FloatValue _timer;
    private readonly float timeThreshold;

    public CheckBoredTimer(FloatValue timer, float timeBored)
    {
        _timer = timer;
        timeThreshold = timeBored;
    }

    public override NodeState Evaluate()
    {
        if (_timer.value > timeThreshold)
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

    //public override NodeState Evaluate()
    //{
    //    // Jika timer lebih dari 10 menit maka akan masuk tree SETELAH bored
    //    if (_timer.value > 600f)
    //    {
    //        Debug.Log("timer value > 600f");
    //        _npc.notIdle = true;
    //        _npc.notInterested = true;
    //        _npc.notBored = true;
    //        state = NodeState.SUCCESS;
    //        return state;
    //    }
    //    // Jika timer diantara 5 - 10 menit maka tetap bored
    //    else if (_timer.value > 300f && _timer.value < 600f)
    //    {
    //        Debug.Log("timer value > 300 dan < 600 ");
    //        state = NodeState.FAILURE;
    //        return state;
    //    }
    //    // Jika timer kurang dari 5 menit
    //    else
    //    {
    //        Debug.Log("timer value < 300f");
    //        state = NodeState.SUCCESS;
    //        return state;
    //    }
    //}
}
