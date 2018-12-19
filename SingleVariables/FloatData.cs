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
    
    public bool CanReset;

    [ContextMenu("Reset Start Data")]
    public void OnEnable()
    {
        StartValue = Value;
    }

    public void OnDisable()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        if (CanReset)
        {
            Value = StartValue;
        }
    }

    
    public void UpdateValue(float i)
    {
        Value += i;
    }

    public void UpdateValue(Object data)
    {
        var newData = data as FloatData;
        Value += newData.Value;
    }

    public void SetValue(Object data)
    {
        var newData = data as FloatData;
        Value = newData.Value;
    }
    
    public void SetValue(float number)
    {
        Value = number;
    }
}

public interface IDataVars
{
    void OnEnable();
    void OnDisable();
    void UpdateValue(Object data);
    void SetValue(Object data);
    void ResetValue();
}