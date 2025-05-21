using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private SpeechRecognition speechRecognition;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private bool isCountdown;
    //[SerializeField]
    //private float time;
    [SerializeField]
    private FloatValue time;
    public bool isRunning;

    TimeSpan timespan;

    // Start is called before the first frame update
    //void Start()
    //{
    //    speechRecognition.StartTimer += StartTimer;
    //    speechRecognition.StopTimer += StopTimer;
    //}

    //private void OnDestroy()
    //{
    //    speechRecognition.StartTimer -= StartTimer;
    //    speechRecognition.StopTimer -= StopTimer;
    //}

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (isCountdown)
                time.value -= Time.deltaTime;
            else
                time.value += Time.deltaTime;

            if (isCountdown && time.value < 0)
            {
                time.ResetValue();
                isRunning = false;
            }

            timespan = TimeSpan.FromSeconds(time.value);

            timerText.text = String.Format("{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
    }

    public void StartTimer()
    {
        //time.ResetValue();
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
