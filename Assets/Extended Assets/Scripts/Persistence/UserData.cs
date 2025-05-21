using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New User Data", menuName = "User Data")]
public class UserData : ScriptableObject
{
    public string uniqueID;
    public StringValue textSpeechRecognition;
    public FloatValue wpm;
    public FloatValue timer;
    public FloatValue volume;
    public NPC NPC1;
    public NPC NPC2;
    public NPC NPC3;
    public NPC NPC4;
    public NPC NPC5;
    public Hand leftHand;
    public Hand rightHand;
}
