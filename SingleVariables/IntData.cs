using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : NameId
{
    public int value;
    private int currentValue;
    public UnityEvent decrementEvent, valueChangeEvent,atZeroEvent, compareTrueEvent, enableEvent, atMinValue;

    private void OnEnable()
    {
        enableEvent?.Invoke();
    }

    public void SetValue(int amount)
    {
        value = amount;
        valueChangeEvent.Invoke();
    }
    public void UpdateFromCurrentValue()
    {
        value = currentValue;
        valueChangeEvent.Invoke();
    }

    public void UpdateCurrentValue()
    {
        currentValue = value;
        valueChangeEvent.Invoke();
    }
    
    public void UpdateValue(int amount)
    {
        value += amount;
        valueChangeEvent.Invoke();
    }
    
    public void IncrementValue()
    {
        value++;
        valueChangeEvent.Invoke();
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
        valueChangeEvent.Invoke();
    }
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
        value = newData.value;
        valueChangeEvent.Invoke();
    }

    public void CompareValue(IntData data)
    {
        if (value < data.value)
        {
            value = data.value;
            valueChangeEvent.Invoke();
        }
        if (value == data.value)
        {
            compareTrueEvent.Invoke();
        }
    }
    
    public void CompareValue(int num)
    {
        if (value < num)
        {
            value = num;
        }
        if (value == num)
        {
            compareTrueEvent.Invoke();
        }
    }

    public void CheckMinValue(int num)
    {
        if (value <= num)
        {
            value = num;
            atMinValue.Invoke();
        }
    }
}