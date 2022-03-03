using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    [SerializeField] private float value;
    public UnityEvent minValueEvent, maxValueEvent, updateValueEvent;

    public float Value
    {
        get => value;
        set => this.value = value;
    }

    public void SetValue (float amount)
    {
        Value = amount;
        updateValueEvent.Invoke();
    }

    public void UpdateValue(float amount)
    {
        Value += amount;
        updateValueEvent.Invoke();
    }

    public void IncrementValue() => Value ++;

    public void UpdateValue(FloatData data)
    {
        if (data != null) Value += data.Value;
    }

    public void SetValue(FloatData data)
    {
        if (data != null) Value = data.Value;
    }
    
    public void CheckMinValue(float minValue)
    {
        if (!(Value < minValue)) return;
        minValueEvent.Invoke();
        Value = minValue;
    }

    public void CheckMaxValue(float maxValue)
    {
        if (!(Value >= maxValue)) return;
        maxValueEvent.Invoke();
        Value = maxValue;
    }
}