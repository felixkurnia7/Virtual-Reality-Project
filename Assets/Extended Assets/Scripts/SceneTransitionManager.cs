using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuScreen;
    [SerializeField]
    private GameObject communicationScreen;
    [SerializeField]
    private GameObject leadershipsScreen;
    [SerializeField]
    private GameObject LoadingScreen;
    [SerializeField]
    private Slider loadingSlider;

    [SerializeField]
    private float timer;

    [SerializeField]
    private FadeCanvas _fade;
    private float alpha = 0.0f;
    [SerializeField]
    private CanvasGroup canvasGroup = null;

    public void MainMenuGoToSceneAsync(string sceneName)
    {
        menuScreen.SetActive(false);
        communicationScreen.SetActive(false);
        leadershipsScreen.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(GoToSceneAsyncRoutineSlider(sceneName));
    }

    public void GoToSceneAsync(string sceneName)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneName));
    }

    //public void GoToLoadingScene(string sceneToGo)
    //{
    //    StartCoroutine(GoToLoadingSceneRoutine(sceneToGo));
    //}

    IEnumerator GoToSceneAsyncRoutineSlider(string sceneName)
    {
        _fade.StartFadeIn();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        float temp = 0f;

        while (!operation.isDone && temp <= timer)
        {
            float progressiveValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progressiveValue;
            temp += Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator GoToSceneAsyncRoutine(string sceneToGo)
    {
        StartCoroutine(FadeIn(3f));
        
        while (alpha <= 1)
        {
            Debug.Log(alpha);
            yield return null;
        }

        SceneManager.LoadSceneAsync(sceneToGo);
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

    private void SetAlpha(float value)
    {
        alpha = value;
        canvasGroup.alpha = alpha;
    }
}
