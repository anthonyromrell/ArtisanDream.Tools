using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

//Made By Anthony Romrell

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    [FormerlySerializedAs("Value")] public float value;

    
    public void SetValue (float amount)
    {
        value = amount;
    }

    public void UpdateValue(float amount)
    {
        value += amount;
    }

    public void UpdateValue(FloatData data)
    {
        var newData = data as FloatData;
        if (newData != null) value += newData.value;
    }

    public void SetValue(FloatData data)
    {
        var newData = data as FloatData;
        if (newData != null) value = newData.value;
    }
    
    public void CheckMinValue(float minValue)
    {
        if (value <= minValue)
        {
            value = minValue;
        }
    }

    public void CheckMaxValue(float maxValue)
    {
        if (value >= maxValue)
        {
            value = maxValue;
        }
    }
}