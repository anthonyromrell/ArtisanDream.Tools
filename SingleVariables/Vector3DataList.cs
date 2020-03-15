using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Vector3DataList")]
public class Vector3DataList : ScriptableObject
{
    public List<Vector3Data> vector3Datas;
    
    public void ClearList()
    {
        vector3Datas.Clear();
    }
    
    public void AddPositionToList(Transform obj)
    {
        var newObj = CreateInstance<Vector3Data>();
        newObj.value = obj.position;
        vector3Datas.Add(newObj);
    }
    
    public void AddRectTransform (RectTransform obj)
    {
        var newObj = CreateInstance<Vector3Data>();
        newObj.value = obj.position;
        vector3Datas.Add(newObj);
    }
}