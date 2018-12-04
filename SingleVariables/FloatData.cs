using UnityEngine;
using UnityEngine.Events;

//Made By Anthony Romrell

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject, IDataVars
{
    public UnityEvent DisableEvent;
    
    public float value;
    public float startValue;

    public void OnEnable()
    {
        startValue = value;
    }

    public void OnDisable()
    {
        DisableEvent.Invoke();
    }

    public void ResetValue()
    {
        value = startValue;
    }

    public virtual float Value
    {
        get => value;
        set => this.value = value;
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
}

public interface IDataVars
{
    void OnEnable();
    void OnDisable();
    void UpdateValue(Object data);
    void SetValue(Object data);
    void ResetValue();
}