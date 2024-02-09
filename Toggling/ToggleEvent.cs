using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ToggleEvent : ScriptableObject
{
    public UnityEvent onEvent;
    public UnityEvent offEvent;

    // Let's change raise to a property with a public getter
    public UnityAction Raise { get; private set; }

    private void OnEnable()
    {
        Raise = TurnOn;
    }

    public void OnRaise()
    {
        Raise?.Invoke();
    }

    private void TurnOn()
    {
        onEvent?.Invoke();
        Raise = TurnOff;
    }

    private void TurnOff()
    {
        offEvent?.Invoke();
        Raise = TurnOn;
    }
}