using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestCheckVolumeNew : MonoBehaviour
{
    [SerializeField] private SpeechRecognition speechRecognition;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FloatValue volume;
    [SerializeField] private TextMeshProUGUI timerText;
    public string microphoneName; // The name of the microphone
    public int sampleRate = 44100; // Sample rate for the microphone
    public int bufferSize = 256; // Buffer size for audio samples
    private AudioClip audioClip;
    private float[] audioSamples;
    private bool isMicrophoneAvailable;
    private bool isRecording;
    private float recordingStartTime;
    private float totalVolume;
    private int volumeSampleCount;

    void Start()
    {
        //speechRecognition.StartCheckVolume += StartVolumeRecording;
        //speechRecognition.StopCheckVolume += StopVolumeRecording;
        speechRecognition.CheckVolume += CheckVolume;
        if (Microphone.devices.Length > 0)
        {
            microphoneName = Microphone.devices[0];
            audioClip = Microphone.Start(microphoneName, true, 20, sampleRate);
            audioSamples = new float[bufferSize];
            isMicrophoneAvailable = true;
        }
        else
        {
            Debug.LogError("No microphone detected");
            isMicrophoneAvailable = false;
        }
        startButton.onClick.AddListener(StartVolumeRecording);
        stopButton.onClick.AddListener(StopVolumeRecording);
        stopButton.interactable = false;
    }

    void Update()
    {
        if (isMicrophoneAvailable && isRecording)
        {
            int micPosition = Microphone.GetPosition(microphoneName);

            if (micPosition >= bufferSize)
            {
                int offset = (micPosition - bufferSize) % audioClip.samples;
                audioClip.GetData(audioSamples, offset);
                float currentVolume = CalculateVolume(audioSamples);

                volume.value = currentVolume;
                text.text = $"Current Volume: {volume}";
                Debug.Log($"Volume: {volume}");

                // Accumulate volume data
                totalVolume += currentVolume;
                volumeSampleCount++;

                // Update the timer display
                float elapsedTime = Time.time - recordingStartTime;
                timerText.text = $"Time: {elapsedTime:F2} seconds";
            }
        }
    }

    private void OnDestroy()
    {
        //speechRecognition.StartCheckVolume -= StartVolumeRecording;
        //speechRecognition.StopCheckVolume -= StopVolumeRecording;
        speechRecognition.CheckVolume -= CheckVolume;
    }

    void StartVolumeRecording()
    {
        startButton.interactable = false;
        stopButton.interactable = true;
        isRecording = true;
        recordingStartTime = Time.time;
        totalVolume = 0;
        volumeSampleCount = 0;
    }

    void StopVolumeRecording()
    {
        isRecording = false;
        startButton.interactable = true;
        stopButton.interactable = false;

        if (volumeSampleCount > 0)
        {
            float averageVolume = totalVolume / volumeSampleCount;
            text.text += $"\nAverage Volume: {averageVolume}";
            Debug.Log($"Average Volume: {averageVolume}");
        }
    }

    void CheckVolume(float[] samples)
    {
        float currentVolume = CalculateVolume(audioSamples);

        volume.value = currentVolume;
        text.text = $"Current Volume: {volume}";
        Debug.Log($"Volume: {volume}");
    }

    float CalculateVolume(float[] samples)
    {
        float sum = 0.0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; // Square of the sample
        }
        float rms = Mathf.Sqrt(sum / samples.Length); // Root Mean Square
        return rms * 1000.0f; // Scale for better visualization
    }
}
