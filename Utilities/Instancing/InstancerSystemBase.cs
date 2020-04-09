using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Utilities/InstancerSystem")]
public class InstancerSystemBase : ScriptableObject
{
    public Vector3DataSystem vector3DataSystem;
    public GameObject prefab;
    public Vector3 location;
    public InstanceConfigBase instanceConfig;
    
    public void InstanceObj()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newInstance = Instantiate(prefab,location, Quaternion.identity);
        instanceConfig.ConfigureInstance(newInstance);
    }
    
    public void InstanceToRandomStartPoint()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newInstance = Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
        instanceConfig.ConfigureInstance(newInstance);
    }
    
    public void InstanceToRandomStartPointWithStartPointData()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newInstance = Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
        newInstance.GetComponent<Vector3DataSystemBehaviour>().vector3DataObj = vector3DataSystem.MoveFromCurrentList();
        instanceConfig.ConfigureInstance(newInstance);
    }

    public void InstanceAndParent(Transform parentObj)
    {
        var newInstance = Instantiate(prefab, parentObj);
        instanceConfig.ConfigureInstance(newInstance);
    }
}