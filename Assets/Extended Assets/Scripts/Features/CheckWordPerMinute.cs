using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using TMPro;
using System.Linq;

public class CheckWordPerMinute : MonoBehaviour
{
    [SerializeField]
    private RunWhisper runWhisper;
    [SerializeField]
    private WordPerMinuteUI wpmUI;
    [SerializeField]
    private FloatValue time;
    [SerializeField]
    private FloatValue WPM;
    public float words;
    public float total;

    private void Awake()
    {
        runWhisper.CheckWMP += CountWPM;
    }

    private void Start()
    {
        ResetWPM();
    }

    private void OnDestroy()
    {
        runWhisper.CheckWMP -= CountWPM;
    }

    private void ResetWPM()
    {
        WPM.ResetValue();
        time.ResetValue();
    }

    void CountWPM(string responseText)
    {
        //WPM.ResetValue();
        int newWordCount = CountWords(responseText);
        Debug.Log(newWordCount);
        // Update word count
        //WPM.value += newWordCount;
        words = newWordCount;

        if (time.value < 60)
        {
            WPM.listValues.Add(words);
            WPM.total = WPM.listValues.Sum();
            WPM.value = WPM.total;
        }
        else
        {
            //// Calculate WPM OLD !!!!!!!!!!!!!!
            //float durationInMinutes = time.value / 60f; // Convert seconds to minutes
            //WPM.listValues.Add(words);
            //WPM.value += words / durationInMinutes;

            // Calculate WPM NEW !!!!!!!!!!!!!!!!
            float durationInMinutes = time.value / 60f; // Convert seconds to minutes
            WPM.listValues.Add(words);
            WPM.total = WPM.listValues.Sum();
            WPM.value = WPM.total / durationInMinutes;
        }
    }

    int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Split text by whitespace and count the words
        string[] words = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
