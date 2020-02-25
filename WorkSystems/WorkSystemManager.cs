using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class WorkSystemManager : ScriptableObject
{
    [Serializable]
    public struct possibleWork
    {
        public NameId nameIdObj;
        public WorkSystem workSystemObj;
        public UnityEvent workEvent;
    }

    public List<possibleWork> workIdList;
}
