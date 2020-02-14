using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class ToggleEvent : ScriptableObject
{
    [FormerlySerializedAs("OnEvent")] public UnityEvent onEvent;
    [FormerlySerializedAs("OffEvent")] public UnityEvent offEvent;
    [FormerlySerializedAs("Raise")] public UnityAction raise;
    
    private void OnEnable()
    {
        raise = TurnOn;
    }

    public void OnRaise()
    {
        raise();
    }
    
    private void TurnOn()
    {
        onEvent.Invoke();
        raise = TurnOff;
    }

    private void TurnOff()
    {
        offEvent.Invoke();
    }
}