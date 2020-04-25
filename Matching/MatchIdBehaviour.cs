using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MatchIdBehaviour : IdBehaviour
{
  
   [Serializable]
   public struct possibleMatch
   {
      public NameId nameIdObj;
      public UnityEvent workEvent, delayedEvent;
   }

   public float holdTime = 0.1f;
   public WaitForSeconds waitObj;
   public List<possibleMatch> triggerEnterMatches, triggerExitMatches;
   private NameId otherIdObj;

   private void Awake()
   {
      waitObj = new WaitForSeconds(holdTime);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<IdBehaviour>() == null) return;
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      StartCoroutine(CheckId(otherIdObj, triggerEnterMatches));
      print(other.name);
   }
   
   private void OnTriggerExit(Collider other)
   {
      if (other.GetComponent<IdBehaviour>() == null) return;
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      StartCoroutine(CheckId(otherIdObj, triggerExitMatches));
   }

   private IEnumerator CheckId(NameId nameId, List<possibleMatch> possibleMatches)
   {
      otherIdObj = nameId;
      foreach (var obj in possibleMatches.Where(obj => otherIdObj == obj.nameIdObj))
      {
         obj.workEvent.Invoke();
         yield return waitObj;
         obj.delayedEvent.Invoke();
      }
   }
}