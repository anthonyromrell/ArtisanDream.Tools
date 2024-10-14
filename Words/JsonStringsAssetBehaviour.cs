using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class JsonStringsAssetBehaviour : MonoBehaviour
{
    public string jsonFilePath = "Assets/ArtisanDream.Tools/Words/StringList.json";
    public string assetFilePath = "Assets/Game/Resources/WordLists/NewWords.asset";
    public List<string> stringListToWrite;
    public UnityEvent onStartEvent;
    
    void Start()
    {
        onStartEvent?.Invoke();
    }
    
    
    public void GetJson()
    {
        // Get JSON data from the file and create a ScriptableObject asset from it
        GetJsonAndCreateAsset(jsonFilePath, assetFilePath);
    }
    
    public void SetJson()
    {
        // Set JSON file with stringListToWrite data
        SetJsonFile(stringListToWrite, jsonFilePath);
    }

    private void SetJsonFile(List<string> stringList, string filePath)
    {
        StringListData dataToWrite = new StringListData
        {
            stringList = stringList
        };

        string jsonToWrite = JsonUtility.ToJson(dataToWrite);

        File.WriteAllText(filePath, jsonToWrite);
    }

    private void GetJsonAndCreateAsset(string jsonFilePath, string assetFilePath)
    {
        var jsonFromFile = File.ReadAllText(jsonFilePath);

        var dataFromFile = JsonUtility.FromJson<StringListData>(jsonFromFile);

        var createdAsset = ScriptableObject.CreateInstance<StringList>();
        createdAsset.stringListObj = dataFromFile.stringList;

#if UNITY_EDITOR
        string uniqueAssetFilePath = AssetDatabase.GenerateUniqueAssetPath(assetFilePath);
        AssetDatabase.CreateAsset(createdAsset, uniqueAssetFilePath);
        AssetDatabase.SaveAssets();
#endif
    }
}