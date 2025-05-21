using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordPerMinuteUI : MonoBehaviour
{
    [SerializeField]
    private FloatValue WPM;
    [SerializeField]
    private TextMeshProUGUI wpmPractice;
    [SerializeField]
    private TextMeshProUGUI wpmResult;

    // Update is called once per frame
    void Update()
    {
        ShowWPMUI();
    }

    private void ShowWPMUI()
    {
        if (wpmPractice != null)
        {
            wpmPractice.text = WPM.value.ToString("F1");
        }

        if (wpmResult != null)
        {
            wpmResult.text = WPM.value.ToString("F1");
        }
    }

    public void ResetWPM()
    {
        WPM.ResetValue();
    }
}
