using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchIdBehaviour : IdBehaviour
{
    [Serializable]
    public struct PossibleMatch
    {
        public NameId nameIdObj;
        public WorkSystem WorkObj;
    }
    
    private NameId otherIdObj;
    public List<PossibleMatch> workIdList;
    
    
    private void OnTriggerEnter(Collider other)
    {
        otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
        print(otherIdObj);
        CheckId();
    }

    private void CheckId()
    {
        foreach (var obj in workIdList)
        {
            obj.WorkObj.NameIdObj = otherIdObj;
            if (obj.nameIdObj == otherIdObj)
            {
                obj.WorkObj.Work();
            }
        }
    }
}