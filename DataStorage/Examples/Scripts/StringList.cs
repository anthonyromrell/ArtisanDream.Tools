using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "DataStorage", menuName = "Objects/String List")]
    public class StringList : ScriptableObject
    {
        [FormerlySerializedAs("NameList")] public List<string> nameList;
        [FormerlySerializedAs("SingleName")] public string singleName;
    }
