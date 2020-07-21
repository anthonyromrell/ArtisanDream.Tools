using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : NameId
{
    public int value;
    private int currentValue;
    public UnityEvent decrementEvent, atZeroEvent, compareTrueEvent;
    
    public void SetValue(int amount)
    {
        value = amount;
    }
    public void UpdateFromCurrentValue()
    {
        value = currentValue;
    }

    public void UpdateCurrentValue()
    {
        currentValue = value;
    }
    
    public void UpdateValue(int amount)
    {
        value += amount;
    }
    
    public void IncrementValue()
    {
        value++;
    }

    public void DecrementToZero()
    {
        if (value > 0)
        {
            value--;
            decrementEvent.Invoke();
        }
        if (value == 0){
            atZeroEvent.Invoke();
        }
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) value += newData.value;
    }
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
        value = newData.value;
    }

    public void CompareValue(IntData data)
    {
        if (value == data.value)
        {
            compareTrueEvent.Invoke();
        }
    }
    
    public void CompareValue(int data)
    {
        if (value == data)
        {
            compareTrueEvent.Invoke();
        }
    }
}