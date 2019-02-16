using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendTransformTrigger : MonoBehaviour
{
    private GameAction sendTransformAction;
    private AiBehaviour ai;
    public AITriggerChase AiChaseObj;
    private AITriggerChase newChaseObj;

    private void OnEnable()
    {
        ai = GetComponentInParent<AiBehaviour>();
        newChaseObj = Instantiate(AiChaseObj);  
        ai.OnStart = newChaseObj;
        ai.OnExit = newChaseObj;
      //  ai.ChangeBase(newChaseObj);
    }

    private void OnTriggerEnter(Collider other)
    {
        newChaseObj.Destination = other.transform;
    }
}