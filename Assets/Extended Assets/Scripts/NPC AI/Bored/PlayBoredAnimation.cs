using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayBoredAnimation : Node
{
    private readonly Animator anim;

    public PlayBoredAnimation(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Play bored anim");
        anim.SetBool("idle", false);
        anim.SetBool("listening", false);
        anim.SetBool("bored", true);
        anim.SetBool("interested", false);
        anim.SetBool("confused", false);

        state = NodeState.SUCCESS;
        return state;
    }
}
