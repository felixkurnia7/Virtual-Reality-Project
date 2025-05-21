using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayConfusedAnimation : Node
{
    private readonly Animator anim;

    public PlayConfusedAnimation(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Play confused anim");
        anim.SetBool("idle", false);
        anim.SetBool("interested", false);
        anim.SetBool("bored", false);
        anim.SetBool("listening", false);
        anim.SetBool("confused", true);

        state = NodeState.SUCCESS;
        return state;
    }
}
