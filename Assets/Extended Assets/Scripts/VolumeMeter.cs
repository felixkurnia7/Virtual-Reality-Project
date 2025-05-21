using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMeter : MonoBehaviour
{
    public string microphoneName;  // Set this in the Inspector or dynamically at runtime
    public int sampleSize = 1024;  // Size of the sample buffer
    public float volumeThreshold = 0.1f;  // Threshold to consider as "loud"

    private AudioSource audioSource;
    [SerializeField] private float[] samples;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            // Create an AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Microphone.Start(null, false, 1, AudioSettings.outputSampleRate);
            audioSource.loop = true;
            audioSource.mute = true;  // We don't want to hear the microphone input
            samples = new float[sampleSize];
            while (Microphone.GetPosition(microphoneName) <= 0) { } // Wait until the microphone starts recording
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No microphone devices found.");
        }
    }

    void Update()
    {
        if (audioSource != null)
        {
            // Get the audio data
            audioSource.GetOutputData(samples, 0);

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

    void OnApplicationQuit()
    {
        // Clean up microphone
        if (audioSource != null)
        {
            Microphone.End(microphoneName);
        }
    }
}
