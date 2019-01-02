using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject, IDataVars
{
    [SerializeField] private int value;
    private int StartValue { get; set; }
    
    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public void ResetValue()
    {
        Value = StartValue;
    }
    
    [ContextMenu("Reset Start Data")]
    public void ResetStartValue()
    {
        StartValue = Value;
    }

    public void UpdateValue(int i)
    {
        Value += i;
    }

    public void UpdateValue(Object data)
    {
        var newData = data as IntData;
        if (newData != null) Value += newData.Value;
    }
    
    public void SetValue(Object data)
    {
        var newData = data as IntData;
        if (newData == null) return;
            Value = newData.Value;
    }
}