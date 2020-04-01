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
}