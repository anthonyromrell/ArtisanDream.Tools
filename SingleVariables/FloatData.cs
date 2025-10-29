using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/FloatData")]
public class FloatData : NameId
{
    [SerializeField] private float value,  minValue, maxValue;

    public UnityEvent<float> valueOutOfRange;
    public UnityEvent onValueChanged, onValueZero;

    public float Value
    {
        get => value;
        set
        {
            this.value = value;
            onValueChanged.Invoke();
            ClampValue();
        }
    }

    public void UpdateValue(float amount)
    {
        Value += amount;
    }

    public void UpdateValue(FloatData data)
    {
        Value += data.Value;
    }

    public void SetValue(FloatData data)
    {
        Value = data.Value;
    }

    private void ClampValue()
    {
        if (!(Value < minValue) && !(Value > maxValue)) return;
        valueOutOfRange.Invoke(Value);
        Value = Mathf.Clamp(Value, minValue, maxValue);
   
        if (value == 0)
        {
            onValueZero.Invoke();
        }
    }
}