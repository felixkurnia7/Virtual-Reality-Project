using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class UI_History : MonoBehaviour
{
    public Action<UserData, GameObject> InitializeData;
    [SerializeField] SaveLoadSystem saveLoadManager;
    [SerializeField] GameObject saveSlot;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Dictionary<string, string> DictUniqueID = new();

    // List to store references to instantiated prefabs
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();
    int index = 1;
    string selectedOption;

    // Start is called before the first frame update
    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        saveLoadManager.CreateHistorySlot += CreateSlot;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        saveLoadManager.CreateHistorySlot -= CreateSlot;
    }

    private void OnDropdownValueChanged(int index)
    {
        selectedOption = dropdown.options[index].text;
    }

    public void DeleteData()
    {
        //saveLoadManager.DeleteData(GetUniqueID(selectedOption));
        // Close History UI so when open it again, it reset
    }

    public void DeleteAllData()
    {
        saveLoadManager.DeleteAllData();
        // Close History UI so when open it again, it reset
    }

    public void DeleteAllHistoryWhenOpen()
    {
        foreach (GameObject prefab in instantiatedPrefabs)
        {
            Destroy(prefab);
        }

        instantiatedPrefabs.Clear();
    }

    private void StoreUniqueID(string uniqueID, string name)
    {
        DictUniqueID[name] = uniqueID;
    }

    private string GetUniqueID(string key)
    {
        if (DictUniqueID.ContainsKey(key))
        {
            return DictUniqueID[key];
        }

        return "";
    }

    private string DisplayKey(string key)
    {
        if (DictUniqueID.ContainsKey(key))
        {
            return key;
        }
        return "";
    }

    public void ClearDictionary()
    {
        DictUniqueID.Clear();
        index = 1;
        dropdown.options.Clear();
    }

    public void SetDropdownValue()
    {
        if (instantiatedPrefabs.Count == 0)
        {
            return;
        }
        else
        {
            dropdown.value = 0;
        }
    }

    private void CreateSlot(UserData data)
    {
        data.name = $"Data {index}";
        StoreUniqueID(data.uniqueID, data.name);

        int eyeContactDone = 0;
        if (data.NPC1.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC2.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC3.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC4.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC5.eyeContactDone == true)
            eyeContactDone++;

        float handMovement = (data.leftHand.score + data.rightHand.score) / 2;

        GameObject slot = Instantiate(saveSlot);
        instantiatedPrefabs.Add(slot);
        slot.transform.SetParent(transform, false);

        TextMeshProUGUI[] texts = slot.GetComponentsInChildren<TextMeshProUGUI>();

        //for (int i = 0; i < texts.Length; i++)
        //{
        //    Debug.Log(texts[i]);
        //}


        dropdown.options.Add(new TMP_Dropdown.OptionData(DisplayKey(data.name)));

        if (texts[1] != null)
        {
            texts[1].text = data.wpm.value.ToString();
        }

        if (texts[3] != null)
        {
            texts[3].text = eyeContactDone.ToString();
        }

        if (texts[5] != null)
        {
            texts[5].text = data.volume.value.ToString();
        }

        if (texts[7] != null)
        {
            texts[7].text = data.timer.value.ToString();
        }

        if (texts[9] != null)
        {
            texts[9].text = handMovement.ToString();
        }

        if (texts[10] != null)
        {
            texts[10].text = DisplayKey(data.name);
            //texts[10].text = data.uniqueID;
        }

        index++;
    }
}
