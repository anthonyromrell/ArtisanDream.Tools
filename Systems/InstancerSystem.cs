using UnityEngine;

[CreateAssetMenu(menuName = "System/Generator")]
public class InstancerSystem : ScriptableObject
{
    public Vector3DataSystem vector3DataSystem;
    public GameObject prefab;
    
    public void InstanceToRandomStartPoint()
    {
        Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
    }
    
    public void InstanceToRandomStartPointWithStartPointData()
    {
        if (vector3DataSystem.currentList.vector3Datas.Count <= 0) return;
        var newPrefab = Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
        newPrefab.GetComponent<Vector3DataBehaviour>().vector3DataObj = vector3DataSystem.MoveFromCurrentList();
    }
}