using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ToggleEvent : ScriptableObject
{
    public UnityEvent onEvent;
    public UnityEvent offEvent;
    public UnityAction raise;
    
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