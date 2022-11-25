using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandAloneActionsEventsBehaviour : MonoBehaviour
{
    public UnityEvent event1, event2, event3;

    public void InvokeEvent1()
    {
        event1.Invoke();
    }
    
    public void InvokeEvent2()
    {
        event2.Invoke();
    }
    
    public void InvokeEvent3()
    {
        event3.Invoke();
    }
    
    public void RaiseGameAction (GameAction gameActionObj)
    {
        gameActionObj.raiseNoArgs();
    }
}
