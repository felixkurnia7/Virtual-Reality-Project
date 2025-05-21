using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayListeningAnimation : Node
{
    private readonly Animator anim;

    public PlayListeningAnimation(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Play listening anim");
        anim.SetBool("idle", false);
        anim.SetBool("listening", true);
        anim.SetBool("bored", false);
        anim.SetBool("interested", false);
        anim.SetBool("confused", false);

        state = NodeState.SUCCESS;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
