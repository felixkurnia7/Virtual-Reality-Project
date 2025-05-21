using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeContactUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI eyeContactTextPractice;
    [SerializeField]
    private TextMeshProUGUI eyeContactTextResult;

    [SerializeField]
    private NPC npc1;
    [SerializeField]
    private NPC npc2;
    [SerializeField]
    private NPC npc3;
    [SerializeField]
    private NPC npc4;
    [SerializeField]
    private NPC npc5;

    [SerializeField]
    private NPC panel1;
    [SerializeField]
    private NPC panel2;
    [SerializeField]
    private NPC panel3;
    [SerializeField]
    private NPC panel4;
    [SerializeField]
    private NPC panel5;

    private int totalPractice;
    public int totalResult;

    // Update is called once per frame
    void Update()
    {
        CheckEyeContactUI();
    }

    private void CheckEyeContactUI()
    {
        if (eyeContactTextPractice != null)
            eyeContactTextPractice.text = totalPractice.ToString();

        if (eyeContactTextResult != null)
            eyeContactTextResult.text = totalResult.ToString();
    }

    public void EyeContactFinish()
    {
        totalResult++;
    }

    public void PanelFinish()
    {
        totalPractice++;
    }

    public void ResetEyeContact()
    {
        totalResult = 0;
        totalPractice = 0;
    }
}
