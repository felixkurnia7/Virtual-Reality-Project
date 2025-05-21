using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSoftSkills : MonoBehaviour
{
    [Header("SPEECH RECOGNITION")]
    [SerializeField]
    private GameObject speechRecognitionUI;
    [SerializeField]
    private GameObject speechRecognitionSystem;
    [SerializeField]
    private GameObject checkVolumeSystem;
    [SerializeField]
    private GameObject CheckWPMSystem;
    [SerializeField]
    private GameObject welcomeSR;
    [SerializeField]
    private GameObject ASR;
    [SerializeField]
    private GameObject WPM;
    [SerializeField]
    private GameObject volumeSpeak;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject secondaryButton;
    [SerializeField]
    private GameObject resetSpeechRecognition;
    [SerializeField]
    private GameObject infoButtonSpeechRecognition;
    [SerializeField]
    private GameObject informationSpeechRecognition;

    [Header("EYE CONTACT")]
    [SerializeField]
    private GameObject eyeContact;
    [SerializeField]
    private GameObject eyeContactSystem;
    [SerializeField]
    private GameObject welcomeEC;
    [SerializeField]
    private GameObject panelEC;
    [SerializeField]
    private GameObject eyeContactUI;
    [SerializeField]
    private GameObject resetEyeContact;
    [SerializeField]
    private GameObject infoButtonEyeContact;
    [SerializeField]
    private GameObject informationEyeContact;

    [Header("HAND MOVEMENT")]
    [SerializeField]
    private GameObject handMovement;
    [SerializeField]
    private GameObject handMovementSystem;
    [SerializeField]
    private GameObject welcomeHM;
    [SerializeField]
    private GameObject leftPanel;
    [SerializeField]
    private GameObject rightPanel;
    [SerializeField]
    private GameObject resetHandMovement;
    [SerializeField]
    private GameObject infoButtonHandMovement;
    [SerializeField]
    private GameObject informationHandMovement;
    [SerializeField]
    private GameObject warningHandMovement;

    private int index;

    public void SelectPractice(int value)
    {
        index = value;
        SpawnPractice();
    }

    void SpawnPractice()
    {
        switch(index)
        {
            case 1:
                speechRecognitionUI.SetActive(true);
                speechRecognitionSystem.SetActive(true);
                checkVolumeSystem.SetActive(true);
                CheckWPMSystem.SetActive(true);
                welcomeSR.SetActive(true);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);
                resetSpeechRecognition.SetActive(false);
                infoButtonSpeechRecognition.SetActive(false);
                informationSpeechRecognition.SetActive(false);

                //eyeContact.SetActive(false);
                //eyeContactSystem.SetActive(false);
                //welcomeEC.SetActive(false);
                //panelEC.SetActive(false);
                //eyeContactUI.SetActive(false);
                ////infoButtonEyeContact.SetActive(false);
                ////resetEyeContact.SetActive(false);

                //handMovement.SetActive(false);
                //handMovementSystem.SetActive(false);
                //welcomeHM.SetActive(false);
                //leftPanel.SetActive(false);
                //rightPanel.SetActive(false);
                ////resetHandMovement.SetActive(false);
                ////infoButtonHandMovement.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(true);
                break;
            case 2:
                //speechRecognitionUI.SetActive(false);
                //speechRecognitionSystem.SetActive(false);
                //checkVolumeSystem.SetActive(false);
                //CheckWPMSystem.SetActive(false);
                //welcomeSR.SetActive(false);
                //ASR.SetActive(false);
                //WPM.SetActive(false);
                //volumeSpeak.SetActive(false);
                //timer.SetActive(false);
                ////resetSpeechRecognition.SetActive(false);
                ////infoButtonSpeechRecognition.SetActive(false);

                eyeContact.SetActive(true);
                eyeContactSystem.SetActive(true);
                welcomeEC.SetActive(true);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);
                infoButtonEyeContact.SetActive(false);
                resetEyeContact.SetActive(false);
                informationEyeContact.SetActive(false);

                //handMovement.SetActive(false);
                //handMovementSystem.SetActive(false);
                //welcomeHM.SetActive(false);
                //leftPanel.SetActive(false);
                //rightPanel.SetActive(false);
                ////resetHandMovement.SetActive(false);
                ////infoButtonHandMovement.SetActive(false);

                gameObject.SetActive(false);

                //secondaryButton.SetActive(false);
                break;
            case 3:
                //speechRecognitionUI.SetActive(false);
                //speechRecognitionSystem.SetActive(false);
                //checkVolumeSystem.SetActive(false);
                //CheckWPMSystem.SetActive(false);
                //welcomeSR.SetActive(false);
                //ASR.SetActive(false);
                //WPM.SetActive(false);
                //volumeSpeak.SetActive(false);
                //timer.SetActive(false);
                ////resetSpeechRecognition.SetActive(false);
                ////infoButtonSpeechRecognition.SetActive(false);

                //eyeContact.SetActive(false);
                //eyeContactSystem.SetActive(false);
                //welcomeEC.SetActive(false);
                //panelEC.SetActive(false);
                //eyeContactUI.SetActive(false);
                ////infoButtonEyeContact.SetActive(false);
                ////resetEyeContact.SetActive(false);

                handMovement.SetActive(true);
                handMovementSystem.SetActive(true);
                welcomeHM.SetActive(true);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetHandMovement.SetActive(false);
                infoButtonHandMovement.SetActive(false);
                informationHandMovement.SetActive(false);
                warningHandMovement.SetActive(false);

                gameObject.SetActive(false);

                //secondaryButton.SetActive(false);
                break;
            default:
                speechRecognitionUI.SetActive(false);
                speechRecognitionSystem.SetActive(false);
                checkVolumeSystem.SetActive(false);
                CheckWPMSystem.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);
                resetSpeechRecognition.SetActive(false);
                infoButtonSpeechRecognition.SetActive(false);
                informationSpeechRecognition.SetActive(false);

                eyeContact.SetActive(false);
                eyeContactSystem.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);
                infoButtonEyeContact.SetActive(false);
                resetEyeContact.SetActive(false);
                informationEyeContact.SetActive(false);

                handMovement.SetActive(false);
                handMovementSystem.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetHandMovement.SetActive(false);
                infoButtonHandMovement.SetActive(false);
                informationHandMovement.SetActive(false);
                warningHandMovement.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(false);
                break;
        }
    }
}
