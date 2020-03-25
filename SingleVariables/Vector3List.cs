using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Vector3List")]
public class Vector3List : ScriptableObject
{
    public List<Vector3> vector3s;
    
    public void ClearList()
    {
        vector3s.Clear();
    }
    
    public void AddPositionToList(Transform obj)
    {
        vector3s.Add(obj.position);
    }
    
    public void AddRectTransform (RectTransform obj)
    {
        var newObj = obj.transform.position;
        vector3s.Add(newObj);
    }
}