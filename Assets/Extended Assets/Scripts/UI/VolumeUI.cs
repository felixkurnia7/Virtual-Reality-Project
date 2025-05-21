using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeUI : MonoBehaviour
{
    [SerializeField]
    private FloatValue volume;
    [SerializeField]
    private TextMeshProUGUI volumePractice;
    [SerializeField]
    private TextMeshProUGUI volumeResult;

    // Update is called once per frame
    void Update()
    {
        ShowVolumeUI();
    }

    private void ShowVolumeUI()
    {
        if (volumePractice != null)
            volumePractice.text = volume.mean.ToString("F2");

        if (volumeResult != null)
            volumeResult.text = volume.mean.ToString("F2");
    }

    public void ResetVolume()
    {
        volume.ResetValue();
    }
}
