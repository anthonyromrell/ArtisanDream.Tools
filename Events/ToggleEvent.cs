using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[CreateAssetMenu]
public class ToggleEvent : ScriptableObject
{
    public UnityEvent OnEvent, OffEvent;
    public UnityAction Raise;

    private void OnEnable()
    {
        Raise = TurnOn;
    }

    public void OnRaise()
    {
        Raise();
    }
    
    private void TurnOn()
    {
        OnEvent.Invoke();
        Raise = TurnOff;
    }

    private void TurnOff()
    {
        OffEvent.Invoke();
        Raise = TurnOn;
    }

    private void DoWork () {
     
    }
}

