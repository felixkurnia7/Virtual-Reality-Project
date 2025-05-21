using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkyRotation : MonoBehaviour
{
    [SerializeField] Material morningSkybox;
    [SerializeField] Material daySkybox;
    [SerializeField] Material afternoonSkybox;
    [SerializeField] Material nightSkybox;
    [SerializeField] float skySpeed;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second);
        if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 10 && morningSkybox != null)
            RenderSettings.skybox = morningSkybox;
        if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 15 && daySkybox != null)
            RenderSettings.skybox = daySkybox;
        if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 19 && afternoonSkybox != null)
            RenderSettings.skybox = afternoonSkybox;
        if (DateTime.Now.Hour >= 19 && DateTime.Now.Hour < 6 && nightSkybox != null)
            RenderSettings.skybox = nightSkybox;

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
    }
}
