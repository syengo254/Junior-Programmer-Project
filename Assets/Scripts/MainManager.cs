using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color TeamColor;
    
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SaveColor()
    {
        SaveData data = new SaveData()
        {
            TeamColor = TeamColor
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "playerdata.json", json);
    }

    public void LoadColor()
    {
        if(File.Exists(Application.persistentDataPath + "playerdata.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "playerdata.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }
    }

    [Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
}
