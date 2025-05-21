using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandMovementUI : MonoBehaviour
{
    [SerializeField]
    private Hand leftHand;
    [SerializeField]
    private Hand rightHand;
    [SerializeField]
    private CheckHandMovement handMovement;
    [SerializeField]
    private TextMeshProUGUI leftHandTextPractice;
    [SerializeField]
    private TextMeshProUGUI rightHandTextPractice;
    [SerializeField]
    private TextMeshProUGUI leftHandTextResult;
    [SerializeField]
    private TextMeshProUGUI rightHandTextResult;
    [SerializeField]
    private TextMeshProUGUI TotalHandMovementResult;

    // Update is called once per frame
    void Update()
    {
        ShowHandMovementUI();
    }

    private void ShowHandMovementUI()
    {
        if (leftHandTextPractice != null)
            leftHandTextPractice.text = leftHand.score.ToString("F1");

        if (rightHandTextPractice != null)
            rightHandTextPractice.text = rightHand.score.ToString("F1");

        if (TotalHandMovementResult != null)
            TotalHandMovementResult.text = handMovement.totalScore.ToString("F1");

        if (leftHandTextResult != null)
            leftHandTextResult.text = leftHand.score.ToString("F1");

        if (rightHandTextResult != null)
            rightHandTextResult.text = rightHand.score.ToString("F1");
    }

    public void ResetHandMovement()
    {
        leftHand.ResetValue();
        rightHand.ResetValue();
    }
}
