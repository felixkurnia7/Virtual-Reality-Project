using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training1 : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField]
    private StringValue text;
    [SerializeField]
    private FloatValue WPM;
    [SerializeField]
    private FloatValue volume;
    [SerializeField]
    private FloatValue time;
    [SerializeField]
    private NPC NPC1;
    [SerializeField]
    private NPC NPC2;
    [SerializeField]
    private NPC NPC3;
    [SerializeField]
    private NPC NPC4;
    [SerializeField]
    private NPC NPC5;
    [SerializeField]
    private Hand leftHand;
    [SerializeField]
    private Hand rightHand;

    [Header("User Interface")]
    [SerializeField]
    private GameObject timerCanvas;
    [SerializeField]
    private GameObject statistic;
    [SerializeField]
    private GameObject resultUI;
    [SerializeField]
    private GameObject preparationUI;
    [SerializeField]
    private EyeContactUI eyeContactUI;
    //[SerializeField]
    //private GameObject whiteboardUI;

    [Header("Systems")]
    [SerializeField]
    private GameObject micRecorder;
    [SerializeField]
    private GameObject speechRecognition;
    [SerializeField]
    private GameObject eyeContactSystem;
    [SerializeField]
    private GameObject checkVolumeSystem;
    [SerializeField]
    private GameObject checkWPMSystem;
    [SerializeField]
    private GameObject fillerWordDetector;
    [SerializeField]
    private GameObject handMovementSystem;
    [SerializeField]
    private Timer timer;

    //[Header("GameObject")]
    //[SerializeField]
    //private GameObject chair1;
    //[SerializeField]
    //private GameObject chair2;
    //[SerializeField]
    //private GameObject chair3;
    //[SerializeField]
    //private GameObject chair4;
    //[SerializeField]
    //private GameObject chair5;

    [Header("NPC")]
    [SerializeField]
    private GameObject Char_NPC1;
    [SerializeField]
    private GameObject Char_NPC2;
    [SerializeField]
    private GameObject Char_NPC3;
    [SerializeField]
    private GameObject Char_NPC4;
    [SerializeField]
    private GameObject Char_NPC5;

    [Header("Fade In & Out")]
    [SerializeField]
    private FadeCanvas _fade;
    private float alpha = 0.0f;
    [SerializeField]
    private CanvasGroup canvasGroup = null;
    public Coroutine CurrentRoutine { private set; get; } = null;

    public void StartTrainingSession()
    {
        StartCoroutine(StartTrainingIEnum());
    }

    public void StopTrainingSession()
    {
        StartCoroutine(StopTrainingIEnum());
    }

    public void EndTrainingSession()
    {
        StartCoroutine(EndTrainingSessionIEnum());
    }

    public void RetryTrainingSession()
    {
        StartCoroutine(RetryTrainingSessionIEnum());
    }

    private void StartTraining()
    {
        timerCanvas.SetActive(true);

        text.ResetText();
        WPM.ResetValue();
        volume.ResetValue();
        time.ResetValue();
        NPC1.ResetNPC();
        NPC2.ResetNPC();
        NPC3.ResetNPC();
        NPC4.ResetNPC();
        NPC5.ResetNPC();
        leftHand.ResetValue();
        rightHand.ResetValue();

        timer.StartTimer();

        preparationUI.SetActive(false);
        statistic.SetActive(false);
        resultUI.SetActive(false);
        eyeContactUI.ResetEyeContact();
        //whiteboardUI.SetActive(false);

        micRecorder.SetActive(true);
        speechRecognition.SetActive(true);
        eyeContactSystem.SetActive(true);
        checkVolumeSystem.SetActive(true);
        handMovementSystem.SetActive(true);
        checkWPMSystem.SetActive(true);
        fillerWordDetector.SetActive(true);

        Char_NPC1.SetActive(true);
        Char_NPC2.SetActive(true);
        Char_NPC3.SetActive(true);
        Char_NPC4.SetActive(true);
        Char_NPC5.SetActive(true);

        Char_NPC1.GetComponent<NPC_AI>().SetNPCToIdle();
        Char_NPC2.GetComponent<NPC_AI>().SetNPCToIdle();
        Char_NPC3.GetComponent<NPC_AI>().SetNPCToIdle();
        Char_NPC4.GetComponent<NPC_AI>().SetNPCToIdle();
        Char_NPC5.GetComponent<NPC_AI>().SetNPCToIdle();

        Char_NPC1.GetComponent<NPCLookAtPlayer>().StartTraining();
        Char_NPC2.GetComponent<NPCLookAtPlayer>().StartTraining();
        Char_NPC3.GetComponent<NPCLookAtPlayer>().StartTraining();
        Char_NPC4.GetComponent<NPCLookAtPlayer>().StartTraining();
        Char_NPC5.GetComponent<NPCLookAtPlayer>().StartTraining();

        //chair1.GetComponent<ObjLookAtPlayer>().StartTraining();
        //chair2.GetComponent<ObjLookAtPlayer>().StartTraining();
        //chair3.GetComponent<ObjLookAtPlayer>().StartTraining();
        //chair4.GetComponent<ObjLookAtPlayer>().StartTraining();
        //chair5.GetComponent<ObjLookAtPlayer>().StartTraining();
    }

    private void StopTraining()
    {
        timerCanvas.SetActive(false);
        
        micRecorder.SetActive(false);
        //speechRecognition.SetActive(false);
        eyeContactSystem.SetActive(false);
        checkVolumeSystem.SetActive(false);
        handMovementSystem.SetActive(false);
        checkWPMSystem.SetActive(false);
        fillerWordDetector.SetActive(false);

        timer.StopTimer();

        statistic.SetActive(true);
        resultUI.SetActive(true);
        preparationUI.SetActive(false);
        //whiteboardUI.SetActive(false);

        Char_NPC1.SetActive(false);
        Char_NPC2.SetActive(false);
        Char_NPC3.SetActive(false);
        Char_NPC4.SetActive(false);
        Char_NPC5.SetActive(false);
    }

    private void EndSession()
    {
        timerCanvas.SetActive(false);

        micRecorder.SetActive(false);
        speechRecognition.SetActive(false);
        eyeContactSystem.SetActive(false);
        checkVolumeSystem.SetActive(false);
        handMovementSystem.SetActive(false);
        checkWPMSystem.SetActive(false);
        fillerWordDetector.SetActive(false);

        timerCanvas.SetActive(false);

        statistic.SetActive(false);
        resultUI.SetActive(false);
        preparationUI.SetActive(true);
        //whiteboardUI.SetActive(true);

        //chair1.GetComponent<ObjLookAtPlayer>().StopTraining();
        //chair2.GetComponent<ObjLookAtPlayer>().StopTraining();
        //chair3.GetComponent<ObjLookAtPlayer>().StopTraining();
        //chair4.GetComponent<ObjLookAtPlayer>().StopTraining();
        //chair5.GetComponent<ObjLookAtPlayer>().StopTraining();

        Char_NPC1.SetActive(false);
        Char_NPC2.SetActive(false);
        Char_NPC3.SetActive(false);
        Char_NPC4.SetActive(false);
        Char_NPC5.SetActive(false);
    }

    public IEnumerator StartTrainingIEnum()
    {
        StartCoroutine(FadeIn(3f));

        while (alpha <= 1)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha >= 0.9f)
            //    StartTraining();
        }

        StartTraining();

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut(3f));

        while (alpha >= 0)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha <= 0.3f)
            //    StartTraining();
        }
    }

    public IEnumerator StopTrainingIEnum()
    {
        StartCoroutine(FadeIn(2f));

        while (alpha <= 1)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha >= 0.9f)
            //    StartTraining();
        }

        StopTraining();

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut(2f));

        while (alpha >= 0)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha <= 0.3f)
            //    StartTraining();
        }
    }

    public IEnumerator EndTrainingSessionIEnum()
    {
        StartCoroutine(FadeIn(2f));

        while (alpha <= 1)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha >= 0.9f)
            //    StartTraining();
        }

        EndSession();

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut(2f));

        while (alpha >= 0)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha <= 0.3f)
            //    StartTraining();
        }

        gameObject.SetActive(false);
    }

    public IEnumerator RetryTrainingSessionIEnum()
    {
        StartCoroutine(FadeIn(3f));

        while (alpha <= 1)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha >= 0.9f)
            //    StartTraining();
        }

        StartTraining();

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut(3f));

        while (alpha >= 0)
        {
            Debug.Log(alpha);
            yield return null;

            //if (alpha <= 0.3f)
            //    StartTraining();
        }
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0.0f;

        while (alpha <= 1.0f)
        {
            SetAlpha(elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0.0f;

        while (alpha >= 0.0f)
        {
            SetAlpha(1 - (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void SetAlpha(float value)
    {
        alpha = value;
        canvasGroup.alpha = alpha;
    }

    public void StartFadeIn(float seconds)
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeIn(seconds));
    }

    public void StartFadeOut(float seconds)
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeOut(seconds));
    }
}
