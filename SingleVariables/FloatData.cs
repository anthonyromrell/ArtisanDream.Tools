using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    [SerializeField] private float value, minValue, maxValue;
    public float Value 
    {
        get => value;
        set
        {
            this.value = value;
            updateValueEvent.Invoke();
        }
    }

    public UnityEvent minValueEvent, maxValueEvent, updateValueEvent;
    
    public void UpdateValue(float amount)
    {
        Value += amount;
    }

    public void IncrementValue()
    {
        Value++;
    }

    public void UpdateValue(FloatData data)
    {
        if (data != null) Value += data.Value;
    }

    public void SetValue(FloatData data)
    {
        if (data != null) Value = data.Value;
    }
    
    public void CheckValueRange()
    {
        CheckValueRange(minValue, maxValue);
    }
    
    private void CheckValueRange(float minValue, float maxValue)
    {
        if (Value < minValue)
        {
            minValueEvent.Invoke();
            Value = minValue;
        }
        else if (Value > maxValue)
        {
            maxValueEvent.Invoke();
            Value = maxValue;
        }
    }
}