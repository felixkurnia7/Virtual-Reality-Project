using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EyeContact : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private LayerMask npcLayer;
    [SerializeField]
    private bool isLookingAtNPC;
    
    [SerializeField]
    private float _eyeContactScore = 0;

    // Update is called once per frame
    void Update()
    {
        CheckEyeContact();
    }

    private void CheckEyeContact()
    {
        RaycastHit hit;
        isLookingAtNPC = Physics.Raycast(mainCamera.gameObject.transform.position, mainCamera.gameObject.transform.forward, out hit, _distance, npcLayer);

        if (isLookingAtNPC && hit.collider.gameObject.GetComponent<Panel>())
        {
            // Increment eye contact value
            _eyeContactScore += Time.deltaTime;
            var NPC = hit.collider.gameObject.GetComponent<Panel>();
            NPC.LookingAtPanel();
            //LookAtNPC?.Invoke();
            // NPC animation changed
        }

        if (isLookingAtNPC && hit.collider.gameObject.GetComponent<NPC_Movement>())
        {
            // Increment eye contact value
            _eyeContactScore += Time.deltaTime;
            var NPC = hit.collider.gameObject.GetComponent<NPC_Movement>();
            NPC.LookedAtNPC();
            //LookAtNPC?.Invoke();
            // NPC animation changed
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isLookingAtNPC ? Color.green : Color.red;
        Gizmos.DrawRay(mainCamera.gameObject.transform.position, mainCamera.gameObject.transform.forward * _distance);
    }
}
