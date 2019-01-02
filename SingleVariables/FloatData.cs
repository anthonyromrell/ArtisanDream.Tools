using UnityEngine;
using UnityEngine.Events;

//Made By Anthony Romrell

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject, IDataVars
{
    [SerializeField] protected float value;
    private float StartValue { get; set; }

    public virtual float Value
    {
        get => value;
        set => this.value = value;
    }

    [ContextMenu("Reset Value")]
    public void ResetValue()
    {
        Value = StartValue;
    }

    [ContextMenu("Reset Start Value")]
    public void ResetStartValue()
    {
        StartValue = Value;
    }

    public void UpdateValue(float i)
    {
        Value += i;
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

    public void SetValue(float number)
    {
        Value = number;
    }
}

public interface IDataVars
{
    void UpdateValue(Object data);
    void SetValue(Object data);
    void ResetValue();
    void ResetStartValue();
}