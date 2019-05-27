using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject
{
    public int Value { get; set; }

    public void SetValue(int amount)
    {
        Value = amount;
    }

    public void UpdateValue(int amount)
    {
        Value += amount;
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value += newData.Value;
    }
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
            Value = newData.Value;
    }
}