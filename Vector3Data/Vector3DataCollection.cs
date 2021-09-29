using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Vector3DataList")]
public class Vector3DataCollection : ScriptableObject
{
    public List<Vector3Data> vector3Datas;
    public int index;
    
    public void RandomizeIndex()
    {
        index = Random.Range(0, vector3Datas.Count - 1);
    }
    
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
    
    public void TransformToVector3Data (Transform[] transforms)
    {
        foreach (var obj in transforms)
        {
            var temp = CreateInstance<Vector3Data>();
            temp.value = obj.position;
            vector3Datas.Add(temp);
        }
        vector3Datas.RemoveAt(0);
    }
}