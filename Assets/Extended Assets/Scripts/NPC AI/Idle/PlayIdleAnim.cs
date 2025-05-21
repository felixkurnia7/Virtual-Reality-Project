using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayIdleAnim : Node
{
    private readonly Animator anim;

    public PlayIdleAnim(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Play idle anim");
        anim.SetBool("idle", true);
        anim.SetBool("listening", false);
        anim.SetBool("bored", false);
        anim.SetBool("interested", false);
        anim.SetBool("confused", false);

        state = NodeState.SUCCESS;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
