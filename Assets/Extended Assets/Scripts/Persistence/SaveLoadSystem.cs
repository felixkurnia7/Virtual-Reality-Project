using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class SaveLoadSystem : MonoBehaviour
{
    public Action<UserData> CreateHistorySlot;
    public Action<bool> CheckHistorySlot;
    [SerializeField] UserData userData;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] List<UserData> AllUserData = new List<UserData>();


    [SerializeField] Dictionary<string, string> DictUniqueID = new();
    // List to store references to instantiated prefabs
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();
    [SerializeField] GameObject saveSlot;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Transform content;
    private string selectedOption;

    private IDataService DataService = new JSONDataService();
    private long saveTime;
    private long loadTime;
    private int index;
    private bool isSaveSlotAvailable;
    TimeSpan timespan;

    // Start is called before the first frame update
    void Start()
    {
        dropdown.onValueChanged.AddListener(SetDropdown);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void SerializeJson()
    {
        CheckHistorySlot?.Invoke(isSaveSlotAvailable);

        long startTime = TimeSpan.TicksPerMillisecond;
        userData.uniqueID = System.Guid.NewGuid().ToString();
        //userData.name = $"Data-{userData.uniqueID}";
        if (DataService.SaveData($"/save-data-{userData.uniqueID}", userData, true))
        {
            saveTime = TimeSpan.TicksPerMillisecond - startTime;
            Debug.Log($"Save Time:  {(saveTime / 1000f):N4}ms");
        }
        else
        {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }
    }

    public void LoadData()
    {
        long startTime = TimeSpan.TicksPerMillisecond;
        try
        {
            UserData data = DataService.LoadData<UserData>("/save-data", true);
            loadTime = TimeSpan.TicksPerMillisecond - startTime;
            inputText.text = "Loaded from file: \r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log($"Load Time:  {(loadTime / 1000f):N4}ms");
        }
        catch (Exception e)
        {
            Debug.LogError($"Could not read file! Show somwthing on the UI here! error: " + e.Message);
        }
    }

    private void SetDropdown(int value)
    {
        selectedOption = dropdown.options[value].text;
    }

    public void DeleteAllHistoryWhenOpen()
    {
        foreach (GameObject prefab in instantiatedPrefabs)
        {
            Destroy(prefab);
        }

        instantiatedPrefabs.Clear();
    }

    public void ClearDictionary()
    {
        DictUniqueID.Clear();
        index = 1;
        dropdown.options.Clear();
    }

    private string GetUniqueID(string key)
    {
        if (DictUniqueID.ContainsKey(key))
        {
            return DictUniqueID[key];
        }

        return "";
    }

    public void SetDropdownValue()
    {
        if (instantiatedPrefabs.Count > 0)
        {
            dropdown.value = 0;
        }
    }

    private void StoreUniqueID(string uniqueID, string name)
    {
        DictUniqueID[name] = uniqueID;
    }

    private string DisplayKey(string key)
    {
        if (DictUniqueID.ContainsKey(key))
        {
            return key;
        }
        return "";
    }

    public void LoadAllData()
    {
        AllUserData = DataService.LoadAllUserData<UserData>(true);
        
        foreach (UserData data in AllUserData)
        {
            //CreateHistorySlot?.Invoke(data);

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

            GameObject slot = Instantiate(saveSlot, content);
            instantiatedPrefabs.Add(slot);
            slot.transform.SetParent(content.transform, false);

            TextMeshProUGUI[] texts = slot.GetComponentsInChildren<TextMeshProUGUI>();

            //for (int i = 0; i < texts.Length; i++)
            //{
            //    Debug.Log(texts[i]);
            //}


            dropdown.options.Add(new TMP_Dropdown.OptionData(DisplayKey(data.name)));

            if (texts[0] != null)
            {
                texts[0].text = DisplayKey(data.name);
                //texts[0].text = data.uniqueID;
                //texts[1].text = data.wpm.value.ToString();
            }

            if (texts[2] != null)
            {
                texts[2].text = data.wpm.value.ToString("F2");
                //texts[3].text = eyeContactDone.ToString();
            }

            if (texts[4] != null)
            {
                texts[4].text = eyeContactDone.ToString();
                //texts[5].text = data.volume.value.ToString();
            }

            if (texts[6] != null)
            {
                texts[6].text = data.volume.mean.ToString("F2");
                //texts[7].text = data.timer.value.ToString();
            }

            if (texts[8] != null)
            {
                timespan = TimeSpan.FromSeconds(data.timer.value);

                //timerText.text = String.Format("{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
                texts[8].text = String.Format("{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
                //texts[9].text = handMovement.ToString();
            }

            if (texts[10] != null)
            {
                texts[10].text = handMovement.ToString();
            }

            if (texts[12] != null)
            {
                texts[12].text = data.textSpeechRecognition.totalFillerWords.ToString();
            }

            index++;
        }
    }

    public void DeleteData()
    {
        DataService.DeleteData($"/save-data-{GetUniqueID(selectedOption)}");
    }

    public void DeleteAllData()
    {
        DataService.DeleteAllData();
    }
}
