using UnityEngine;

//Made By Anthony Romrell

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject
{
    public float value;
    public float startValue;

    private void OnEnable()
    {
        startValue = value;
    }

    private void OnDisable()
    {
        ResetValue();
    }

    public virtual float Value
    {
        get => value;
        set => this.value = value;
    }

    public void UpdateValue(float i)
    {
        Value += i;
        Debug.Log(Value);
    }

    public void UpdateValue(FloatData data)
    {
        Value += data.Value;
    }

    public void ResetValue()
    {
        value = startValue;
    }
}