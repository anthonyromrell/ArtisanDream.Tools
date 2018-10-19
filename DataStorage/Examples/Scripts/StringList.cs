using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "DataStorage", menuName = "Objects/String List")]
    public class StringList : ScriptableObject
    {
        public List<string> NameList;
        public string SingleName;
    }
