using UnityEngine;
using UnityEngine.Events;

public class SimpleMatchID : IdBehaviour
{
    private NameId _otherIdObj;
    public UnityEvent matchEvent, noMatchEvent;
    public virtual void OnTriggerEnter(Collider other)
    {
        CheckMatch(other);
    }

    public virtual void OnTriggerExit(Collider other)
    {
        CheckMatch(other);
    }
    
    private void CheckMatch(Collider other)
    {
        _otherIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
        CheckMatch(_otherIdObj);
    }
    
    // check ide without the collider
    public void CheckMatch(NameId otherId)
    {
        if (otherId == null) return;
        
        if (nameIdObj == otherId)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
        }
    }
}