using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CheckVolumeSpeaking : MonoBehaviour
{
    [SerializeField] private SpeechRecognition speechRecognition;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private FloatValue volume;
    public string microphoneName; // The name of the microphone
    public int sampleRate = 44100; // Sample rate for the microphone
    public int bufferSize = 256; // Buffer size for audio samples

    private float totalVolume;
    void Start()
    {
        //speechRecognition.StartCheckVolume += StartVolumeRecording;
        //speechRecognition.StopCheckVolume += StopVolumeRecording;
        ResetVolumeSpeaking();
        speechRecognition.CheckVolume += CheckVolume;
    }

    private void OnDestroy()
    {
        //speechRecognition.StartCheckVolume -= StartVolumeRecording;
        //speechRecognition.StopCheckVolume -= StopVolumeRecording;
        speechRecognition.CheckVolume -= CheckVolume;
    }

    private void ResetVolumeSpeaking()
    {
        volume.ResetValue();
    }

    void CheckVolume(float[] samples)
    {
        float currentVolume = CalculateVolume(samples);
        volume.numberOfValue++;

        volume.value += currentVolume;
        volume.listValues.Add(currentVolume);

        volume.mean = volume.value / volume.numberOfValue;
        //volume.value = (volume.value + currentVolume) / numberOfVolume;

        // Accumulate volume data
        //totalVolume += currentVolume;
        //volumeSampleCount++;
    }

    float CalculateVolume(float[] samples)
    {
        float sum = 0.0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; // Square of the sample
        }
        float rms = Mathf.Sqrt(sum / samples.Length); // Root Mean Square
        return rms * 2000.0f; // Scale for better visualization
    }

    public void InsertVolume(float value)
    {
        float currentVolume = value;
        volume.numberOfValue++;

        volume.value += currentVolume;
        volume.listValues.Add(currentVolume);

        volume.mean = volume.value / volume.numberOfValue;
    }
}
