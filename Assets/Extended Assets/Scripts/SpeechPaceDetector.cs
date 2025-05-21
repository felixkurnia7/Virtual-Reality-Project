using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechPaceDetector : MonoBehaviour
{
    public AudioSource audioSource;
    public int sampleSize = 2048;
    public float minSilenceDuration = 0.5f; // Minimum duration of silence to consider a pause
    public float silenceThreshold = 0.01f; // Threshold below which the signal is considered silent

    private float[] audioSamples;
    private float lastSpeechTime;
    private float lastPauseTime;
    private bool isSpeaking;

    void Start()
    {
        audioSamples = new float[sampleSize];
        lastSpeechTime = Time.time;
        lastPauseTime = Time.time;
    }

    void Update()
    {
        AnalyzeAudio();
    }

    private void AnalyzeAudio()
    {
        audioSource.GetOutputData(audioSamples, 0);

        float averageAmplitude = CalculateAverageAmplitude(audioSamples);

        if (averageAmplitude > silenceThreshold)
        {
            if (!isSpeaking)
            {
                isSpeaking = true;
                lastSpeechTime = Time.time;
            }
            else
            {
                // Calculate speech pace (words per minute or syllables per minute can be inferred based on application needs)
                float speechDuration = Time.time - lastSpeechTime;
                Debug.Log($"Speaking Pace: {speechDuration} seconds");
            }
        }
        else
        {
            if (isSpeaking)
            {
                isSpeaking = false;
                lastPauseTime = Time.time;

                float pauseDuration = Time.time - lastSpeechTime;
                if (pauseDuration > minSilenceDuration)
                {
                    Debug.Log($"Pause Duration: {pauseDuration} seconds");
                }
            }
        }
    }

    private float CalculateAverageAmplitude(float[] samples)
    {
        float sum = 0.0f;
        foreach (var sample in samples)
        {
            sum += Mathf.Abs(sample);
        }
        return sum / samples.Length;
    }
}
