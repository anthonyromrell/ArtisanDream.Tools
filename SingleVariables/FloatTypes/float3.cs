using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Floats/Float3")]
public class Float3: ScriptableObject
{
    [FormerlySerializedAs("X")] public float x;
    [FormerlySerializedAs("Y")] public float y;
    [FormerlySerializedAs("Z")] public float z;

    public Float3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    [FormerlySerializedAs("V3")] public Vector3 v3;
}