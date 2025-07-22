using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Closed_Captions : MonoBehaviour
{
    [System.Serializable]
    public struct CC
    {
        public float time;
        public string text;
    }

    [SerializeField]
    private CC[] SubtitleCC;

    [SerializeField]
    private TextMeshProUGUI text_CC;

    public void StartClosedCaptions()
    {
        StartCoroutine(StartCC());
    }

    private IEnumerator StartCC()
    {
        foreach (var lines in SubtitleCC)
        {
            text_CC.text = lines.text;

            yield return new WaitForSecondsRealtime(lines.time);
        }
    }
}
