using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMeterWithClip : MonoBehaviour
{
    public string microphoneName;  // Set this in the Inspector or dynamically at runtime
    public int sampleSize = 1024;  // Size of the sample buffer
    public float volumeThreshold = 0.1f;  // Threshold to consider as "loud"
    public float clipLength = 1.0f;  // Length of the clip in seconds

    private AudioClip audioClip;
    private float[] samples;
    private int sampleRate;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            // Start recording
            sampleRate = AudioSettings.outputSampleRate;
            audioClip = Microphone.Start(microphoneName, true, (int)clipLength, sampleRate);
            samples = new float[sampleSize];

            // Wait until the microphone starts recording
            while (Microphone.GetPosition(microphoneName) <= 0) { }
        }
        else
        {
            Debug.LogError("No microphone devices found.");
        }
    }

    void Update()
    {
        if (audioClip != null)
        {
            // Get the audio data from the clip
            int micPosition = Microphone.GetPosition(microphoneName);
            if (micPosition > sampleSize)
            {
                audioClip.GetData(samples, micPosition - sampleSize);

                // Calculate the RMS (Root Mean Square) volume
                float rms = 0f;
                for (int i = 0; i < sampleSize; i++)
                {
                    rms += samples[i] * samples[i];
                }
                rms = Mathf.Sqrt(rms / sampleSize);

                // Convert RMS to decibels
                float volume = 20f * Mathf.Log10(rms / 0.1f);  // The 0.1f is the reference value for silence

                // Output volume level
                if (volume > volumeThreshold)
                {
                    Debug.Log($"Volume: {volume:F2} dB");
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        // Clean up microphone
        if (audioClip != null)
        {
            Microphone.End(microphoneName);
        }
    }
}
