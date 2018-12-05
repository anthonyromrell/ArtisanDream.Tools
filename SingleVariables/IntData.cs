using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject, IDataVars
{
    public int value;
    public int startValue;
    public bool CanReset;

    public int Value
    {
        get => value;
        set => this.value = value;
    }
    
    public void OnEnable()
    {
        startValue = value;
    }

    public void OnDisable()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        if (CanReset)
        {
            value = startValue;
        }
    }

    public void UpdateValue(int i)
    {
        Value += i;
    }
    
    public void UpdateValue(IntData data)
    {
        Value += data.Value;
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value += newData.Value;
    }
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value = newData.Value;
    }
}