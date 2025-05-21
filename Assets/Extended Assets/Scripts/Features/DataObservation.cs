using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObservation : MonoBehaviour
{
    [Header("DATA")]
    [SerializeField]
    private FloatValue wpm;
    [SerializeField]
    private FloatValue volume;
    [SerializeField]
    private FloatValue timer;
    [SerializeField]
    private NPC npc1;
    [SerializeField]
    private NPC npc2;
    [SerializeField]
    private NPC npc3;
    [SerializeField]
    private NPC npc4;
    [SerializeField]
    private NPC npc5;
    [SerializeField]
    private Hand leftHand;
    [SerializeField]
    private Hand rightHand;
    [SerializeField]
    private StringValue text;

    [Header("SPEECH RECOGNITION")]
    [SerializeField]
    private SpeechRecognition speechRecognition;
    [SerializeField]
    private CheckVolumeSpeaking checkVolume;
    [SerializeField]
    private string textToAdd;
    [SerializeField]
    private float volumeValue;

    [Header("TIME")]
    [SerializeField]
    private float timeValue;

    [Header("EYE CONTACT")]
    [SerializeField]
    private EyeContactUI eyeContactUI;
    [SerializeField]
    private int eyeContact;

    [Header("HAND MOVEMENT")]
    [SerializeField]
    private float leftHandValue;
    [SerializeField]
    private float rightHandValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClearData()
    {
        wpm.ResetValue();
        volume.ResetValue();
        timer.ResetValue();
        npc1.ResetNPC();
        npc2.ResetNPC();
        npc3.ResetNPC();
        npc4.ResetNPC();
        npc5.ResetNPC();
        leftHand.ResetValue();
        rightHand.ResetValue();
        text.ResetText();
    }

    public void InsertSpeechData()
    {
        speechRecognition.CallData(textToAdd);
        checkVolume.InsertVolume(volumeValue);
    }

    public void InserTime()
    {
        timer.value = timeValue;
    }

    public void InsertEyeContact()
    {
        eyeContactUI.totalResult = eyeContact;
    }

    public void InsertHandMovement()
    {
        leftHand.value = leftHandValue;
        rightHand.value = rightHandValue;
    }
}
