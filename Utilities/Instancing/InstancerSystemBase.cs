using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstancerSystemBase : ScriptableObject
{
    public Vector3DataSystem vector3DataSystem;
    public GameObject prefab;
    public Vector3 location;
    
    public void InstanceObj()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newObj = Instantiate(prefab,location, Quaternion.identity);
        ConfigureInstance(newObj);
    }
    
    public void InstanceToRandomStartPoint()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newObj = Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
        ConfigureInstance(newObj);
    }
    
    public void InstanceToRandomStartPointWithStartPointData()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newObj = Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
        newObj.GetComponent<Vector3DataBehaviour>().vector3DataObj = vector3DataSystem.MoveFromCurrentList();
        ConfigureInstance(newObj);
    }

    public abstract void ConfigureInstance(GameObject newObj);
}
