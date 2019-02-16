using UnityEngine;

[CreateAssetMenu(menuName = "Vector3/Data")]
public class Vector3Data : ScriptableObject
{
    public Vector3 Value;

    public void UpdateValue(Transform obj)
    {
        Value = obj.localPosition;
    }
}