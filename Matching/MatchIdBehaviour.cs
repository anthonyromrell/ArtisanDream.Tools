using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MatchIdBehaviour : IdBehaviour
{
  
   [Serializable]
   public struct PossibleMatch
   {
      public NameId nameIdObj;
      public bool canRepeat;
      public float repeatTime;
      public UnityEvent workEvent, repeatEvent, delayedEvent;
      internal WaitForSeconds RepeatWaitObj;
   }

   public float holdTime = 0.1f;
   public WaitForSeconds waitObj;
   public List<PossibleMatch> triggerEnterMatches, triggerExitMatches;
   private NameId otherIdObj;

   private void Awake()
   {
      waitObj = new WaitForSeconds(holdTime);
      foreach (var obj in triggerEnterMatches)
      {
         var possibleMatch = obj;
         possibleMatch.RepeatWaitObj = new WaitForSeconds(possibleMatch.repeatTime);
      }
      
      foreach (var obj in triggerExitMatches)
      {
         var possibleMatch = obj;
         possibleMatch.RepeatWaitObj = new WaitForSeconds(possibleMatch.repeatTime);
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<IdBehaviour>() == null) return;
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      StartCoroutine(CheckId(otherIdObj, triggerEnterMatches));
   }
   
   private void OnTriggerExit(Collider other)
   {
      if (other.GetComponent<IdBehaviour>() == null) return;
      otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      StartCoroutine(CheckId(otherIdObj, triggerExitMatches));
   }

   public void StopIdCoroutine()
   {
      foreach (var obj in triggerEnterMatches)
      {
         var possibleMatch = obj;
         if (possibleMatch.nameIdObj == otherIdObj)
         {
            possibleMatch.canRepeat = false;
         }
      }
   }
   
   private IEnumerator CheckId(NameId nameId, List<PossibleMatch> possibleMatches)
   {
      otherIdObj = nameId;
      foreach (var obj in possibleMatches.Where(obj => otherIdObj == obj.nameIdObj))
      {
         obj.workEvent.Invoke();

         while (obj.canRepeat)
         {
            yield return obj.RepeatWaitObj;
            obj.repeatEvent.Invoke();
         }
         
         yield return waitObj;
         obj.delayedEvent.Invoke();
      }
   }
}