using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Vector3Data")]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
       
    public void UpdateValue(Transform obj)
    {
        //value = obj.TransformPoint(obj.localPosition);
        value = obj.position;
    }

    public void UpdateTransform(Transform obj)
    {
        obj.localPosition = value;  
    }
}