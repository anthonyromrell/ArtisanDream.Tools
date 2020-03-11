using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/Float Axis")]
public class FloatAxis : FloatData
{
    [FormerlySerializedAs("Axis")] public string axis = "Horizontal";

    public  float Value => Value * Input.GetAxis(axis);
}