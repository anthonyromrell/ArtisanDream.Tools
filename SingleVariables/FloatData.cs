using UnityEngine;

//Made By Anthony Romrell

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    public float value;

    public void SetValue (float amount)
    {
        value = amount;
    }

    public void UpdateValue(float amount)
    {
        value += amount;
    }

    public void IncrementValue()
    {
        value ++;
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