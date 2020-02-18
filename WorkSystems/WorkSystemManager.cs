using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WorkSystemManager : ScriptableObject
{
    [Serializable]
    public struct possibleMatches
    {
        public NameId nameIdObj;
        public WorkSystem workSystemObj;
    }

    public List<possibleMatches> workIdList;
}
