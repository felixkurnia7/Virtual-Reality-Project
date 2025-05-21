using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckHandMovement : MonoBehaviour
{
    [SerializeField]
    private Transform leftHandController;
    [SerializeField]
    private Transform rightHandController;
    [SerializeField]
    private GameObject warningHandMovement;
    [SerializeField]
    private TextMeshProUGUI warningText;
    [SerializeField]
    private float movementThreshold;
    [SerializeField]
    private float stationaryTimeThreshold;
    [SerializeField]
    private float smoothFactor;
    [SerializeField]
    private Hand leftHand;
    [SerializeField]
    private Hand rightHand;
    [SerializeField]
    private FloatValue timer;

    private Vector3 prevLeftHandPosition;
    private Vector3 prevRightHandPosition;
    private float stationaryTime;
    private float smoothedLeftVelocity;
    private float smoothedRightVelocity;

    public float totalScore;

    // Start is called before the first frame update
    void Start()
    {
        ResetHandValue();
        prevLeftHandPosition = leftHandController.position;
        prevRightHandPosition = rightHandController.position;
        stationaryTime = 0.0f;
        smoothedLeftVelocity = 0.0f;
        smoothedRightVelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curLeftHandPosition = leftHandController.position;
        Vector3 curRightHandPosition = rightHandController.position;
        float leftVelocity = (curLeftHandPosition - prevLeftHandPosition).magnitude / Time.deltaTime;

        float rightVelocity = (curRightHandPosition - prevRightHandPosition).magnitude / Time.deltaTime;

        CheckHandPosition(leftVelocity, rightVelocity);

        prevLeftHandPosition = curLeftHandPosition;
        prevRightHandPosition = curRightHandPosition;

        CountScore();
    }

    public void ResetHandValue()
    {
        leftHand.ResetValue();
        rightHand.ResetValue();
    }
    
    // Apakah nilai hand movement itu dari per waktu atau per threshold value?
    public void CountScore()
    {
        leftHand.score = (leftHand.value / leftHand.movementThreshold) * 100f;
        rightHand.score = (rightHand.value / leftHand.movementThreshold) * 100f;

        if (leftHand.score >= 100f)
            leftHand.score = 100f;
        if (rightHand.score >= 100f)
            rightHand.score = 100f;

        totalScore = (leftHand.score + rightHand.score) / 2;
    }

    private void CheckHandPosition(float leftVelocity, float rightVelocity)
    {
        if (leftHandController.localPosition.y > 1.8f || rightHandController.localPosition.y > 1.8f)
        {
            warningText.text = "Posisi tangan Anda terlalu tinggi!";
            warningHandMovement.SetActive(true);
        }
        else if (leftHandController.localPosition.y < 0.8f || rightHandController.localPosition.y < 0.8f)
        {
            warningText.text = "Posisi tangan Anda terlalu rendah!";
            warningHandMovement.SetActive(true);
        }
        else
        {
            warningHandMovement.SetActive(false);
            CheckHandMove(leftVelocity, rightVelocity);
        }
    }

    private void CheckHandMove(float leftVelocity, float rightVelocity)
    {
        // Apply exponential moving average for smoothing
        smoothedLeftVelocity = smoothFactor * leftVelocity + (1 - smoothFactor) * smoothedLeftVelocity;
        smoothedRightVelocity = smoothFactor * rightVelocity + (1 - smoothFactor) * smoothedRightVelocity;
        //Debug.Log(smoothedVelocity);
        if (smoothedLeftVelocity > movementThreshold)
        {
            stationaryTime = 0.0f;
            //Debug.Log("Left Hand is moving");
            //leftHandText.text = "Moving";
            leftHand.HandMoving();
        }
        else
        {
            stationaryTime += Time.deltaTime;
            if (stationaryTime >= stationaryTimeThreshold)
            {
                //Debug.Log("Left Hand is stationary");
                //leftHandText.text = "";
            }
        }

        if (smoothedRightVelocity > movementThreshold)
        {
            stationaryTime = 0.0f;
            //Debug.Log("Right Hand is moving");
            //rightHandText.text = "Moving";
            rightHand.HandMoving();
        }
        else
        {
            stationaryTime += Time.deltaTime;
            //if (stationaryTime >= stationaryTimeThreshold)
            //    rightHandText.text = "";
            //Debug.Log("Right Hand is stationary");
        }
    }
}
