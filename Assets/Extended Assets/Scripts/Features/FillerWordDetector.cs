using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillerWordDetector : MonoBehaviour
{
    [SerializeField]
    private SpeechRecognition speechRecognition;
    [SerializeField]
    private List<string> fillerWords = new();
    [SerializeField]
    private StringValue recognizedSpeech;

    private void Awake()
    {
        speechRecognition.CheckFillerWord += CheckFillerWord;
    }

    private void OnDestroy()
    {
        speechRecognition.CheckFillerWord -= CheckFillerWord;
    }

    public void CheckFillerWord(string text)
    {
        string[] words = text.ToLower().Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> detectedFillerWords = new();

        foreach (string word in words)
        {
            foreach (var filler in fillerWords)
            {
                if (LevenshteinDistance(word, filler) <= 1)
                {
                    detectedFillerWords.Add(word);
                    recognizedSpeech.fillerWords.Add(word);
                    break;
                }
            }
            // Kalo gak mau pake Levenshtein Distance
            //if (fillerWords.Contains(word))
            //{
            //    detectedFillerWords.Add(word);
            //}
        }

        if (detectedFillerWords.Count > 0)
        {
            Debug.Log("Detected filler words: " + string.Join(", ", detectedFillerWords));
            recognizedSpeech.CountFillerWords();
        }
        else
        {
            Debug.Log("No filler words detected.");
        }
    }

    private int LevenshteinDistance(string s, string t)
    {
        if (string.IsNullOrEmpty(s)) return t.Length;
        if (string.IsNullOrEmpty(t)) return s.Length;

        int[,] matrix = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
            matrix[i, 0] = i;
        for (int j = 0; j <= t.Length; j++)
            matrix[0, j] = j;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                matrix[i, j] = Math.Min(Math.Min(
                    matrix[i - 1, j] + 1,    // Deletion
                    matrix[i, j - 1] + 1),   // Insertion
                    matrix[i - 1, j - 1] + cost); // Substitution
            }
        }

        return matrix[s.Length, t.Length];
    }
}
