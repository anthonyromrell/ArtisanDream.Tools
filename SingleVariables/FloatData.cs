using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

//Made By Anthony Romrell

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject
{
    [SerializeField] protected float value;

    public virtual float Value
    {
        get => value;
        set => this.value = value;
    }
    
    public void SetValue (float amount)
    {
        Value = amount;
    }

    public void UpdateValue(float amount)
    {
        Value += amount;
    }

    public void UpdateValue(Object data)
    {
        var newData = data as FloatData;
        if (newData != null) Value += newData.Value;
    }

    public void SetValue(Object data)
    {
        var newData = data as FloatData;
        if (newData != null) Value = newData.Value;
    }
    
    public void CheckMinValue(float minValue)
    {
        if (Value <= minValue)
        {
            Value = minValue;
        }
    }

    public void CheckMaxValue(float maxValue)
    {
        if (Value >= maxValue)
        {
            Value = maxValue;
        }
    }
}