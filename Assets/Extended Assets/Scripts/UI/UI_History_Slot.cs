using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_History_Slot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {

    }

    private void DeleteData()
    {
        Debug.Log("Deleting Data!");
    }

    //private void GetData(UserData data, GameObject go)
    //{
    //    UiHistory = go.GetComponent<UI_History>();
    //    wpmText.text = data.wpm.value.ToString();
    //}
}
