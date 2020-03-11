using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/Float Bool")]
public class FloatBool : FloatData
{
    [FormerlySerializedAs("InputType")] public string inputType;

//    public override float Value
//    {
//        get
//        {
//            if (Input.GetButton(InputType))
//                return value;
//            else
//                return 0;
//        }
    //}
}