using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/String", fileName = "Create New String")]
public class StringValue : ScriptableObject
{
    public string text;
    public List<string> fillerWords = new();
    public int totalFillerWords;

    public void ResetText()
    {
        text = "";
        fillerWords.Clear();
        totalFillerWords = 0;
    }

    public void CountFillerWords()
    {
        totalFillerWords = fillerWords.Count;
    }
}
