using System.Collections.Generic;
using BehaviorTree;

public class NPC_AI : Tree
{
    public NPC npc;
    public StringValue text;
    public FloatValue timer;
    public FloatValue volume;
    public FloatValue wpm;

    public bool notIdle = false;
    public bool notListening = false;
    public bool isInterested = false;
    public bool isConfused = false;
    public bool isBored = false;

    public string _header = "--- IDLE THRESHOLD ---";
    public float timeIdle;

    public string __header = "--- LISTENING THRESHOLD ---";
    public float timeListening;

    public string ___header = "--- INTERESTED THRESHOLD ---";
    public float wpmInterested;
    public float eyeContactInterested;

    public string ____header = "--- CONFUSED THRESHOLD ---";
    public float wpmConfused;
    public float eyeContactConfused;

    public string _____header = "--- BORED THRESHOLD ---";
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
                        new CheckInterestedWPM(wpm, wpmInterested),

                        new CheckInterestedEyeContact(npc, eyeContactInterested),

                        new PlayInterestedAnim(transform)
                    }),

                    new Sequence(new List<Node>
                    {
                        new CheckConfusedWPM(wpm, wpmConfused),

                        new CheckConfusedEyeContact(npc, eyeContactConfused),

                        new PlayConfusedAnimation(transform)
                    })
                })
            })
        });

        return root;
    }
}
