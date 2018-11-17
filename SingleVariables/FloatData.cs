using UnityEngine;

//Made By Anthony Romrell

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject
{
    public float value;

    public virtual float Value
    {
        get { return value; }
        set { value = value; }
    }
}