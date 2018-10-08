using System.Collections.Generic;
using UnityEngine;

namespace ArtisanDream.Tools
{
    [CreateAssetMenu(fileName = "DataStorage", menuName = "Data Storage/String List")]
    public class StringData : ScriptableObject
    {
        public List<string> NameList;
        public string SingleName;
    }
}