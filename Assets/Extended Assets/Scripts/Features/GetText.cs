using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class GetText : MonoBehaviour
{
    [SerializeField]
    private FileBrowserDialog fileBrowser;
    [SerializeField]
    private Transform contentWindow;
    [SerializeField]
    private GameObject textPrefabs;

    private void Awake()
    {
        fileBrowser.DisplayText += DisplayText;
    }

    private void OnDestroy()
    {
        fileBrowser.DisplayText -= DisplayText;
    }

    void DisplayText(string path)
    {
        if (contentWindow.childCount > 0)
        {
            for (int i = 0; i < contentWindow.childCount; i++)
            {
                Destroy(contentWindow.GetChild(i).gameObject);
            }
        }

        textPrefabs.GetComponent<TextMeshProUGUI>().text = "";

        List<string> fileLines = File.ReadAllLines(path).ToList();

        foreach (string line in fileLines)
        {
            //Debug.Log(line);
            textPrefabs.GetComponent<TextMeshProUGUI>().text += line + "\n";
        }

        Instantiate(textPrefabs, contentWindow);
    }
}
