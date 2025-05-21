using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollide : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    [SerializeField] private AudioClip bookSound;
    private float volumeSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision collision)
    {
        //code to get the velocity magnitude and convert to volume sound
        volumeSound = rb.linearVelocity.magnitude; //maginitude converts velocity (Vector3) to a float. Refer to Unity API for more info
        //Debug.Log(volumeSound); //optional test

        audioSource.PlayOneShot(bookSound, volumeSound);

    }
}
