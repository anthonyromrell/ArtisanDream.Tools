using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Utilities/Data Storage Object")]
public class DataStorage : ScriptableObject
{
    public ScriptableObject data;
    public List<ScriptableObject> listData;

    private void SaveData<T>(T obj) where T : Object
    {
        if (obj == null) return;
        PlayerPrefs.SetString(obj.name, JsonUtility.ToJson(obj));
    }

    private void LoadData<T>(T obj) where T : Object
    {
        if (obj == null) return;
        var jsonData = PlayerPrefs.GetString(obj.name);
        if (!string.IsNullOrEmpty(jsonData))
            JsonUtility.FromJsonOverwrite(jsonData, obj);
    }

    public void SaveAllData()
    {
        SaveData(data);
        foreach (var obj in listData)
        {
            SaveData(obj);
        }
    }
    
    public void LoadAllData()
    {
        LoadData(data);
        foreach (var obj in listData)
        {
            LoadData(obj);
        }
    }
}