using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechRecognitionUI : MonoBehaviour
{
    [SerializeField]
    private StringValue textSpeechRecognition;
    [SerializeField]
    private TextMeshProUGUI textPractice;
    [SerializeField]
    private TextMeshProUGUI textResult;
    [SerializeField]
    private TextMeshProUGUI fillerWord;

    // Update is called once per frame
    void Update()
    {
        ShowTextSpeechRecognitionUI();
    }
    
    private void ShowTextSpeechRecognitionUI()
    {
        if (textPractice != null)
            textPractice.text = textSpeechRecognition.text;

        if (textResult != null)
            textResult.text = textSpeechRecognition.text;

        if (fillerWord != null)
            fillerWord.text = textSpeechRecognition.totalFillerWords.ToString();
    }

    public void ResetText()
    {
        textSpeechRecognition.ResetText();
    }
}
