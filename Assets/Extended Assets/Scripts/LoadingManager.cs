using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadingManager : MonoBehaviour
{
    public Action GoToScene;

    public string sceneToGo { get; set; }

    private void Start()
    {
        Debug.Log("Start Function called");
        Debug.Log(GoToScene);
        Debug.Log(sceneToGo);
        CheckSceneToGo();
    }

    void Update()
    {
        
    }

    void CheckSceneToGo()
    {
        if (SceneManager.GetActiveScene().name == "Loading")
            GoToScene?.Invoke();
    }
}
