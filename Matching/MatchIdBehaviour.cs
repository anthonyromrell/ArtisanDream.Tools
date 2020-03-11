using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchIdBehaviour : IdBehaviour
{
  
   [Serializable]
   public struct possibleMatch
   {
      public NameId nameIdObj;
      public UnityEvent workEvent;
   }

   public List<possibleMatch> nameIdList;
   
   
   private NameId otherIdObj;
   
   private void OnTriggerEnter(Collider other)
   {
      var nameId = other.GetComponent<IdBehaviour>().nameIdObj;
      if (nameId == null) return;
      
      otherIdObj = nameId;
      CheckId();
   }

   private void CheckId()
   {
      foreach (var obj in nameIdList)
      {
         if (otherIdObj == obj.nameIdObj)
         {
            obj.workEvent.Invoke();
         }
      }
   }
}

