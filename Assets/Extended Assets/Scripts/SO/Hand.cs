using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create New Hand", menuName = "New Features/Hand")]
public class Hand : ScriptableObject
{
    public float value;
    public float movementThreshold = 10f;
    public float score;

    public void ResetValue()
    {
        value = 0f;
        score = 0f;
    }

    public void HandMoving()
    {
        value += Time.deltaTime * 0.35f;
    }
}
