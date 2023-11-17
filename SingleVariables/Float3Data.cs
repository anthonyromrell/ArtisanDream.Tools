using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Float3Data")]
public class Float3Data : NameId
{
    public Vector3 v3;

    // Optional: Methods to set or modify the Vector3 value
    public void SetValue(float x, float y, float z)
    {
        v3 = new Vector3(x, y, z);
    }

    public void SetValue(Vector3 value)
    {
        v3 = value;
    }

    public Vector3 GetValue()
    {
        return v3;
    }
}