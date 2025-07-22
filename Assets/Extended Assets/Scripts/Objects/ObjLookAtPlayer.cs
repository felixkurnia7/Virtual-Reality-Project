using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5.0f; // Speed of rotation
    public Quaternion originRotation;
    public bool trainingStart;

    private void Awake()
    {
        //player = Camera.main.transform;
        trainingStart = false;
    }

    private void Start()
    {
        originRotation = transform.rotation;
    }

    void Update()
    {
        if (player != null && trainingStart == true)
        {
            // Get the direction to the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Ignore the Y component to keep the character upright

            if (direction != Vector3.zero) // Prevent zero vector errors
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Adjust the rotation by adding a -90 degree rotation on the X axis
                targetRotation *= Quaternion.Euler(-90f, 0f, 0f);

                // Smoothly rotate towards the player
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            transform.rotation = originRotation;
        }
    }

    public void StartTraining()
    {
        trainingStart = true;
    }

    public void StopTraining()
    {
        trainingStart = false;
    }
}
