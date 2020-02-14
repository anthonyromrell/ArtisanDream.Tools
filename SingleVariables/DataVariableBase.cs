using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DataVariableBase : ScriptableObject
{
    [FormerlySerializedAs("EnableEvent")] public UnityEvent enableEvent;
    [FormerlySerializedAs("DisableEvent")] public UnityEvent disableEvent;
    
    public void OnEnable()
    {
        enableEvent.Invoke();
    }

    public void OnDisable()
    {
        disableEvent.Invoke();
    }
}