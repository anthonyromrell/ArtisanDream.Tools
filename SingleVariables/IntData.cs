using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : NameId
{
    public int value;
    public UnityEvent decrementEvent, atZeroEvent;
    
    public void SetValue(int amount)
    {
        value = amount;
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
}