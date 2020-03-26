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

   public List<possibleMatch> triggerEnterMatches, triggerExitMatches;
   
   
   private NameId otherIdObj;
   
   private void OnTriggerEnter(Collider other)
   {
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      CheckId(otherIdObj, triggerEnterMatches);
   }
   
   private void OnTriggerExit(Collider other)
   {
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      CheckId(otherIdObj, triggerExitMatches);
   }

   private void CheckId(NameId nameId, List<possibleMatch> possibleMatches)
   {
      
      if (nameId == null) return;
      
      otherIdObj = nameId;
      foreach (var obj in possibleMatches)
      {
         if (otherIdObj == obj.nameIdObj)
         {
            obj.workEvent.Invoke();
         }
      }
   }
}