using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class NPC_AI : BehaviorTree.Tree
{
    public NPC npc;
    public StringValue text;
    public FloatValue timer;
    public FloatValue volume;
    public FloatValue wpm;
    public MicRecorder micRecorder;

    public bool notIdle = false;
    public bool notListening = false;
    public bool isInterested = false;
    public bool isConfused = false;
    public bool isBored = false;
    [Space]
    [Header("--- IDLE THRESHOLD ---")]
    public float timeIdle;

    [Header("--- LISTENING THRESHOLD ---")]
    public float timeListening;

    [Header("--- INTERESTED THRESHOLD ---")]
    public float wpmInterested;
    public float eyeContactInterested;

    [Header("--- CONFUSED THRESHOLD ---")]
    public float wpmConfused;
    public float eyeContactConfused;

    [Header("--- BORED THRESHOLD ---")]
    public float timeBored;

    public void SetNPCToIdle()
    {
        notIdle = false;
        notListening = false;
        isInterested = false;
        isConfused = false;
        isBored = false;
    }

    protected override Node SetupTree()
    {
        Node root = new Sequence(new List<Node>
        {
            new Selector(new List<Node>
            {
                new CheckIdle(transform),

                new Sequence(new List<Node>
                {
                    new PlayIdleAnim(transform),

                    new CheckIdleTimer(timer, transform, timeIdle)
                })
            }),

            new Selector(new List<Node>
            {
                new CheckListening(transform),

                new Sequence(new List<Node>
                {
                    new PlayListeningAnimation(transform),

                    new CheckListeningTimer(timer, transform, timeIdle, timeListening)
                })
            }),

            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CheckBoredTimer(timer, timeBored),

                    new PlayBoredAnimation(transform)
                }),

                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        new CheckInterestedWPM(micRecorder, wpmInterested),

                        new CheckInterestedEyeContact(npc, eyeContactInterested),

                        new PlayInterestedAnim(transform)
                    }),

                    new Sequence(new List<Node>
                    {
                        new CheckConfusedWPM(micRecorder, wpmConfused),

                        new CheckConfusedEyeContact(npc, eyeContactConfused),

                        new PlayConfusedAnimation(transform)
                    })
                })
            })
        });

        return root;
    }
}
