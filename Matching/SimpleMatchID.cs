using UnityEngine;
using UnityEngine.Events;

public class SimpleMatchID : IdBehaviour
{
    protected NameId OtherIdObj;
    public UnityEvent matchEvent, noMatchEvent;
    public virtual void OnTriggerEnter(Collider other)
    {
        OtherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;

        if (nameIdObj == OtherIdObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
        }
    }
}
