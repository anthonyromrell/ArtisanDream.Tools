using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchIdBehaviour : IdBehaviour
{
   public struct PossibleMatch
   {
      public NameId nameIdObj;
      public bool canRepeat;
      public float repeatTime;
      public UnityEvent workEvent, repeatEvent, delayedEvent;
      internal WaitForSeconds repeatWaitObj;
   }

   public float holdTime = 0.1f;
   private WaitForSeconds _waitObj;
   public List<PossibleMatch> triggerEnterMatches, triggerExitMatches;
   private NameId _otherIdObj;

   private void Awake()
   {
      _waitObj = new WaitForSeconds(holdTime);
      InitializeRepeatWaitObjects(triggerEnterMatches);
      InitializeRepeatWaitObjects(triggerExitMatches);
   }
   
   private void InitializeRepeatWaitObjects(List<PossibleMatch> matches)
   {
      foreach (var obj in matches)
      {
         var possibleMatch = obj;
         possibleMatch.repeatWaitObj = new WaitForSeconds(possibleMatch.repeatTime);
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      CheckMatch(other);
   }

   private void OnTriggerExit(Collider other)
   {
      CheckMatch(other);
   }

   private void CheckMatch(Component other)
   {
      if (other.GetComponent<IdBehaviour>() == null) return;
      _otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
      StartCoroutine(CheckId(_otherIdObj, triggerEnterMatches));
   }
   
   private IEnumerator CheckId(NameId nameId, List<PossibleMatch> possibleMatches)
   {
      _otherIdObj = nameId;
      foreach (var obj in possibleMatches)
      {
         if (_otherIdObj == obj.nameIdObj)
         {
            obj.workEvent.Invoke();

            while (obj.canRepeat)
            {
               yield return obj.repeatWaitObj;
               obj.repeatEvent.Invoke();
            }

            yield return _waitObj;
            obj.delayedEvent.Invoke();
         }
      }
   }
}