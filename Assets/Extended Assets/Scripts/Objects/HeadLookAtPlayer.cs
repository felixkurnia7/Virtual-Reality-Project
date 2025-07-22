using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform boredPosition;
    public bool bored;
    public bool lookAtPlayer;
    public float rotationSpeed;

    private void Awake()
    {
        player = Camera.main.transform;
    }
    void Update()
    {
        if (player != null)
        {
            // Make the character look at the player's position
            //transform.LookAt(player.position);
            //transform.rotation = Quaternion.Euler(45, 0, 0);
            if (lookAtPlayer)
            {
                // Get the direction to the player
                Vector3 direction = player.position - transform.position;

                if (direction != Vector3.zero) // Prevent zero vector errors
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    // Smoothly rotate towards the player on the Y-axis
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
            }

            if (bored)
            {
                // Get the direction to the player
                Vector3 direction = boredPosition.position - transform.position;

                if (direction != Vector3.zero) // Prevent zero vector errors
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    // Smoothly rotate towards the player on the Y-axis
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }
}
