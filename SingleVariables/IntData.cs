using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : NameId
{
    [SerializeField] private int value;
    private int currentValue;
    public UnityEvent decrementEvent, valueChangeEvent,atZeroEvent, compareTrueEvent;

    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public void SetValue(int amount)
    {
        Value = amount;
        valueChangeEvent.Invoke();
    }
    public void UpdateFromCurrentValue()
    {
        Value = currentValue;
        valueChangeEvent.Invoke();
    }

    public void UpdateCurrentValue()
    {
        currentValue = Value;
        valueChangeEvent.Invoke();
    }
    
    public void UpdateValue(int amount)
    {
        Value += amount;
        valueChangeEvent.Invoke();
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value += newData.Value;
        valueChangeEvent.Invoke();
    }
    
    public void UpdateValueZeroCheck(int num)
    {
        UpdateValue(num);
        ZeroCheck();
    }

    public void ZeroCheck()
    {
        if (Value >= 0)
        {
            value = 0;
        }
    }

    public void IncrementValue()
    {
        Value++;
        valueChangeEvent.Invoke();
    }

    public void DecrementToZero()
    {
        if (Value > 0)
        {
            Value--;
            decrementEvent.Invoke();
        }
        if (Value == 0){
            atZeroEvent.Invoke();
        }
    }

    
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
        Value = newData.Value;
        valueChangeEvent.Invoke();
    }

    public void CompareValue(IntData data)
    {
        if (Value == data.Value)
        {
            compareTrueEvent.Invoke();
        }
    }
    
    public void CompareValue(int data)
    {
        if (Value == data)
        {
            compareTrueEvent.Invoke();
        }
    }
}