using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField]
    private EyeContact eyeContact;
    [SerializeField]
    private NPC npc;
    [SerializeField]
    private float eyeContactThreshold;
    [SerializeField]
    private bool eyeContactDone;
    [SerializeField]
    private EyeContactUI eyeContactUI;

    private void Awake()
    {
        ResetNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if (npc.stare >= eyeContactThreshold && !npc.eyeContactDone)
        {
            eyeContactUI.EyeContactFinish();
            npc.DoneEyeContact();
        }
    }

    public void LookedAtNPC()
    {
        npc.stare += Time.deltaTime;
    }

    public void ResetNPC()
    {
        npc.ResetNPC();
    }
}
