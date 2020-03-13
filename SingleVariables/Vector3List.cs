using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Vector3List")]
public class Vector3List : MonoBehaviour
{
    public List<Vector3> Vector3s;

    public void ClearList()
    {
        Vector3s.Clear();
    }
    
    public void AddPositionToList(Transform obj)
    {
        Vector3s.Add(obj.position);
    }
}
