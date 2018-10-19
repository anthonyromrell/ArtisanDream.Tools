using UnityEngine;

//Made By Anthony Romrell

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : ScriptableObject
{
    [SerializeField] protected float value;

    public virtual float Value
    {
        get => this.value;
        set => this.value = value;
    }
}