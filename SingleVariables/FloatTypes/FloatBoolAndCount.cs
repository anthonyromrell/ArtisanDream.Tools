using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "FloatBoolAndCount", menuName = "Floats/Float Bool And Count")]
public class FloatBoolAndCount : FloatBool
{
    [FormerlySerializedAs("Count")] public IntData count;

    private new void OnEnable()
    {
        if (count != null) count.Value = 0;
    }

//    public override float Value
//    {
//        get
//        {
//            if (Count.Value <= 0) return 0;
//            if (!UnityEngine.Input.GetButtonDown(InputType)) return 0;
//            Count.Value--;
//            return value;
//        }
//    }
}