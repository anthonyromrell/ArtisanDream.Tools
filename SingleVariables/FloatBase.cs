using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "Single Variables/FloatBase")]
public class FloatBase : ScriptableObject
{
    [FormerlySerializedAs("Value")] public float value;
}