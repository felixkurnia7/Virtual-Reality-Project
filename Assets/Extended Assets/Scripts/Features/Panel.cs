using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField]
    private EyeContact eyeContact;
    [SerializeField]
    private NPC npc;
    [SerializeField]
    private float eyeContactThreshold;
    [SerializeField]
    private bool eyeContactDone;
    public float timeToFade = 3.0f;
    [SerializeField]
    private EyeContactUI eyeContactUI;
    public Renderer targetRenderer;

    private void Awake()
    {
        ResetPanel();
        targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npc.stare >= eyeContactThreshold && !npc.eyeContactDone)
        {
            eyeContactUI.PanelFinish();
            npc.DoneEyeContact();
        }

        if (npc.stare <= eyeContactThreshold)
        {
            // Calculate the new alpha value based on the timer
            float alpha = Mathf.Lerp(1f, 0f, npc.stare / eyeContactThreshold);
            SetPanelAlpha(alpha);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    private void SetPanelAlpha(float alpha)
    {
        if (targetRenderer != null)
        {
            Color color = targetRenderer.material.color;
            color.a = alpha;
            targetRenderer.material.color = color;

            // Ensure the material is set to transparent if needed
            Material mat = targetRenderer.material;
            if (alpha < 1f)
            {
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000; // Ensure it's rendered in the transparent queue
            }
        }
    }

    public void ResetPanelAlpha()
    {
        Color color = targetRenderer.material.color;
        color.a = 1f;
        targetRenderer.material.color = color;

        npc.ResetNPC();
    }

    public void LookingAtPanel()
    {
        npc.stare += Time.deltaTime;
    }

    public void ResetPanel()
    {
        npc.ResetNPC();
    }
}
