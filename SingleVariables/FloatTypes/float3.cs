using UnityEngine;

[CreateAssetMenu(menuName = "Floats/Float3")]
public class Float3: ScriptableObject
{
    public float X, Y, Z;

    public Float3(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public Vector3 V3;
}