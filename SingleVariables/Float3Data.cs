using UnityEngine;


[CreateAssetMenu(menuName = "Single Variables/Float3Data")]
public class Float3Data: ScriptableObject
{
    public float x;
    public float y;
    public float z;

    public Float3Data(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 v3;
}