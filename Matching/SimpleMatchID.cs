using System;
using UnityEngine;
using UnityEngine.Events;

public class SimpleMatchID : IdBehaviour
{
    private NameId otherIdObj;
    public UnityEvent matchEvent, noMatchEvent;
    public virtual void OnTriggerEnter(Collider other)
    {
        otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
        if (otherIdObj == null) return;
        
        if (nameIdObj == otherIdObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
        if (otherIdObj == null) return;
        
        if (nameIdObj == otherIdObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
        }
    }
}