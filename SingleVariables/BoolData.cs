using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/BoolData")]
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
        if (valueChange)
        {
            setTrueEvent?.Invoke();
        }
        else
        {
            setFalseEvent?.Invoke();
        }
    }

    public void ToggleValue()
    {
        Value = !Value;
    }
}