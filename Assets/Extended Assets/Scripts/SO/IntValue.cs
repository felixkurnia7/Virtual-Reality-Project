using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/Integer", fileName = "Create New Integer")]
public class IntValue : ScriptableObject
{
    public int value;

    public void ResetValue()
    {
        value = 0;
    }
}
