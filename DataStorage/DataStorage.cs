using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Data Storage/Data Storage Object")]
public class DataStorage : ScriptableObject
{
    public ScriptableObject Data;

    public void SetData()
    {
        if (Data == null) return;
        PlayerPrefs.SetString(Data.name, JsonUtility.ToJson(Data));
    }

    public void GetData()
    {
        if (Data == null) return;
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString(Data.name)))
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(Data.name), Data);
    }
}