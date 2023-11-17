using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject
{
    [SerializeField] private int value, minValue, maxValue;
    public int Value 
    {
        get => value;
        set
        {
            this.value = value;
            InvokeValueChangedEvent();
        }
    }
    private int currentValue;
    public UnityEvent decrementEvent, atZeroEvent, minValueEvent, enableEvent, maxValueEvent, valueChangeEvent;

    private void OnEnable()
    {
        enableEvent?.Invoke();
    }

    private void InvokeValueChangedEvent()
    {
        valueChangeEvent?.Invoke();
    }

    public void UpdateFromCurrentValue()
    {
        Value = currentValue;
    }

    public void UpdateCurrentValue()
    {
        currentValue = Value;
    }

    public void UpdateValue(int amount)
    {
        Value += amount;
    }

    public void IncrementValue()
    {
        Value++;
    }

    public void DecrementToZero()
    {
        if (Value > 0)
        {
            Value--;
            decrementEvent?.Invoke();
        }
        CheckZero();
    }

    private void CheckZero()
    {
        if (Value == 0)
        {
            atZeroEvent?.Invoke();
        }
    }

    public void UpdateValue(Object data)
    {
        if (data is IntData newData)
        {
            Value += newData.Value;
        }
    }

    public void SetValue(Object data)
    {
        if (data is IntData newData)
        {
            Value = newData.Value;
        }
    }
    
    public void CheckValueRange()
    {
        CheckValueRange(minValue, maxValue);
    }
    
    private void CheckValueRange(int minValue, int maxValue)
    {
        if (Value < minValue)
        {
            minValueEvent.Invoke();
            Value = minValue;
        }
        else if (Value > maxValue)
        {
            maxValueEvent.Invoke();
            Value = maxValue;
        }
    }
}