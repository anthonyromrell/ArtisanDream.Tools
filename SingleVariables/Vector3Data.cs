using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Vector3/Data")]
public class Vector3Data : ScriptableObject
{
    [FormerlySerializedAs("Value")] public Vector3 value;
       
    public void UpdateValue(Transform obj)
    {
        value = obj.TransformPoint(obj.localPosition);
    }

    public void UpdateTransform(Transform obj)
    {
        obj.localPosition = value;  
    }
}