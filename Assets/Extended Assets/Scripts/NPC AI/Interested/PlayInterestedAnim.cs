using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayInterestedAnim : Node
{
    private readonly Animator anim;

    public PlayInterestedAnim(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Play interested anim");
        anim.SetBool("idle", false);
        anim.SetBool("interested", true);
        anim.SetBool("bored", false);
        anim.SetBool("listening", false);
        anim.SetBool("confused", false);

        state = NodeState.SUCCESS;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
