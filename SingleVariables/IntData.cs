using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : NameId
{
    public int value;

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
        value ++;
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