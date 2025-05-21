using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPreperationCanvas;
    public bool isActive;

    private void Start()
    {
        isActive = true;
    }

    private void Update()
    {
        if (isActive == true)
            menuPreperationCanvas.SetActive(true);
        else
            menuPreperationCanvas.SetActive(false);
    }

    public void SetPreperationCanvas()
    {
        isActive = !isActive;
    }
}
