using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class IdBehaviour : MonoBehaviour
{
    public UnityEvent startEvent;
    [CanBeNull] public NameId nameIdObj;
    
    protected virtual void Start()
    {
        startEvent.Invoke();
    }
    public void ChangeId(NameId id)
    {
        nameIdObj = id;
    }
}