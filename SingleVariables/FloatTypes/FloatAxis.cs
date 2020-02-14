using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Floats/Float Axis")]
public class FloatAxis : FloatData
{
    [FormerlySerializedAs("Axis")] public string axis = "Horizontal";

    public  float Value => Value * Input.GetAxis(axis);
}