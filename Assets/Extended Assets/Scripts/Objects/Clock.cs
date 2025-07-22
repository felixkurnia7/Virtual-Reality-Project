using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject hourHand;
    [SerializeField] GameObject minuteHand;
    [SerializeField] GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    void UpdateClock()
    {
        float hourAngle = ((DateTime.Now.Hour + (DateTime.Now.Minute / 60)) * 30) + 90;
        float minuteAngle = (DateTime.Now.Minute * (360f / 60)) + 90;
        float secondAngle = (DateTime.Now.Second * (360 / 60)) + 90;

        if (SceneManager.GetActiveScene().name == "Classroom")
        {
            Vector3 targetHourC = new Vector3(0, 0, hourAngle - 90);
            Vector3 targetMinuteC = new Vector3(0, 0, minuteAngle - 90);
            Vector3 targetSecondC = new Vector3(0, 0, secondAngle - 90);

            hourHand.transform.localRotation = Quaternion.Euler(targetHourC);
            minuteHand.transform.localRotation = Quaternion.Euler(targetMinuteC);
            secondHand.transform.localRotation = Quaternion.Euler(targetSecondC);
        }

        if (SceneManager.GetActiveScene().name == "Meeting Room")
        {
            Vector3 targetHour = new Vector3(hourAngle, 0, -90);
            Vector3 targetMinute = new Vector3(minuteAngle, 0, -90);
            Vector3 targetSecond = new Vector3(secondAngle, 0, -90);

            hourHand.transform.localRotation = Quaternion.Euler(targetHour);
            minuteHand.transform.localRotation = Quaternion.Euler(targetMinute);
            secondHand.transform.localRotation = Quaternion.Euler(targetSecond);
        }

        //hourHand.transform.rotation = Quaternion.Slerp(hourHand.transform.rotation, targetHour, Time.deltaTime * smooth);
        //minuteHand.transform.rotation = Quaternion.Slerp(minuteHand.transform.rotation, targetMinute, Time.deltaTime * smooth);
        //secondHand.transform.rotation = Quaternion.Slerp(secondHand.transform.rotation, targetSecond, Time.deltaTime * smooth);
    }
}
