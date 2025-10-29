using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/StringData")]
public class StringData : ScriptableObject
{
    [SerializeField] private string value;

    [FormerlySerializedAs("OnValueChanged")] public UnityEvent onValueChanged;

    public string Value
    {
        get => value;
        set
        {
            this.value = value;
            onValueChanged?.Invoke();
        }
    }

    public void UpdateValue(Object obj)
    {
        if (obj != null)
        {
            Value = obj.name;
        }
    }

    public void UpdateValue(StringData obj)
    {
        if (obj != null)
        {
            Value = obj.Value;
        }
    }

    public void UpdateValue(string obj)
    {
        if (obj != null)
        {
            Value = obj;
        }
    }
}