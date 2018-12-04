using UnityEngine;

[CreateAssetMenu(menuName = "Floats/Float Axis")]
public class FloatAxis : FloatData
{
    public string Axis = "Horizontal";

    public override float Value => value * Input.GetAxis(Axis);
}