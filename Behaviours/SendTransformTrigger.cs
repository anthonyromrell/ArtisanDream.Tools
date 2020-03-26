using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SendTransformTrigger : MonoBehaviour
{
    private GameAction sendTransformAction;
    private AiBehaviour ai;
    [FormerlySerializedAs("AiChaseObj")] public AiTriggerChase aiChaseObj;
    private AiTriggerChase newChaseObj;

    private void OnEnable()
    {
        ai = GetComponentInParent<AiBehaviour>();
        newChaseObj = Instantiate(aiChaseObj);  
//        ai.onStart = newChaseObj;
 //       ai.onExit = newChaseObj;
      //  ai.ChangeBase(newChaseObj);
    }

    private void OnTriggerEnter(Collider other)
    {
        newChaseObj.destination = other.transform;
    }
}