using UnityEngine;

[CreateAssetMenu(menuName = "Instancing/InstanceObject")]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    public IntData indexer;
    
    public void CreateInstance(Transform parent = null)
    {
        Instantiate(prefab, parent ? parent.position : Vector3.zero, Quaternion.identity, parent);
    }
    
    public void InstanceFromV3Collection(Vector3DataCollection collection)
    {
        if (indexer.value < 0 || indexer.value >= collection.vector3Datas.Count)
        {
            Debug.LogWarning("Indexer value out of range.");
            return;
        }
        Instantiate(prefab, collection.vector3Datas[indexer.value].value, Quaternion.identity);
    }
}