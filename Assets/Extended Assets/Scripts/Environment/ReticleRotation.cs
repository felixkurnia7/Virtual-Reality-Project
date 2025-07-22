using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject reticlePrefabs;
    private float scaleSpeed = 0.1f;
    private float maxScale = 1.2f;
    private float minScale = 1f;
    private Vector3 vector3;
    private readonly float speed = 50.0f;

    private bool isScalingUp = true;

    private void Update()
    {
        // Rotate the reticle around the y-axis
        if (Application.isPlaying)
        {
            vector3 = new Vector3(0, 1, 0);
            transform.Rotate(speed * Time.deltaTime * vector3);
        }

        // Scale the reticle up and down
        if (isScalingUp)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x >= maxScale)
            {
                isScalingUp = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x <= minScale)
            {
                isScalingUp = true;
            }
        }
    }
}
