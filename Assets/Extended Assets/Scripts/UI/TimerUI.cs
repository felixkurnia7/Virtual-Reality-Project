using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] FloatValue timer;
    [SerializeField] TextMeshProUGUI timerResult;

    TimeSpan timespan;

    // Update is called once per frame
    void Update()
    {
        ShowTimerUI();
    }

    private void ShowTimerUI()
    {
        if (timerResult != null)
        {
            timespan = TimeSpan.FromSeconds(timer.value);

            timerResult.text = String.Format("{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
    }
}
