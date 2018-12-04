using UnityEngine;

[CreateAssetMenu(menuName = "Floats/Float Bool")]
public class FloatBool : FloatData
{
    public string InputType;

    public override float Value
    {
        get
        {
            if (Input.GetButton(InputType))
                return value;
            else
                return 0;
        }
    }
}