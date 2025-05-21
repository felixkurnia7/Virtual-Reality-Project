using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutPanel : MonoBehaviour
{
    public Renderer targetRenderer;

    private void Awake()
    {
        targetRenderer = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
