using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class TaskNormal : Node
{
    private readonly NPC _npc;
    private readonly StringValue _text;
    private readonly FloatValue _timer;
    private readonly FloatValue _volume;
    private readonly FloatValue _wpm;
    private Animator _anim;

    // Batas value animasi Normal
    private readonly float _eyeContactThreshold;
    private readonly float _textThreshold;
    private readonly float _timerThreshold;
    private readonly float _volumeThreshold;
    private readonly float _wpmThreshold;

    public TaskNormal(NPC npc, StringValue text, FloatValue timer, FloatValue volume, FloatValue wpm, Transform transform)
    {
        _npc = npc;
        _text = text;
        _timer = timer;
        _volume = volume;
        _wpm = wpm;
        _anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        // Jalanin animasi Duduk Nomral
        if (_timer.value < 120)
        {
            _anim.SetBool("idle", true);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
