using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetection : MonoBehaviour
{
    public float detectionRadius = 1f; // radius to detect objects around the GameObject
    public LayerMask detectionLayer;   // define which layer(s) to detect

    void Update()
    {
        // Create a sphere at the position of the GameObject with the given radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        // Check if any colliders were detected
        foreach (Collider col in hitColliders)
        {
            Debug.Log("Detected: " + col.name);
            //col.gameObject.SetActive(false);
        }
    }

    // Optionally, visualize the detection radius in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
