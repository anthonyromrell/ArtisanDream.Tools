using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/BoolData")]
public class BoolData : NameId
{
    [SerializeField] private bool value;
    public UnityEvent onValueChangeEvent, setTrueEvent, setFalseEvent;

    private bool Value
    {
        get => value;
        set
        {
            if (this.value == value) return;
            this.value = value;
            onValueChangeEvent?.Invoke();
        }
    }

    public void SetValue(bool valueChange)
    {
        Value = valueChange;
        TriggerEventsBasedOnValue();
    }

    public void ToggleValue()
    {
        Value = !Value;
        TriggerEventsBasedOnValue();
    }

    private void TriggerEventsBasedOnValue()
    {
        if (Value)
        {
            setTrueEvent?.Invoke();
        }
        else
        {
            setFalseEvent?.Invoke();
        }
    }
}