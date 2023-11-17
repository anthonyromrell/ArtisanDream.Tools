using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/StringData")]
public class StringData : ScriptableObject
{
    [SerializeField] private string value;
    
    private string Value
    {
        get => value;
        set => this.value = value;
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