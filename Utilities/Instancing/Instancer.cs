using UnityEngine;

[CreateAssetMenu(menuName = "Utilities/InstanceObject")]
public class Instancer : ScriptableObject
{
    private Transform parentObj;
    
    public void CreateInstance(GameObject instance)
    {
        Instantiate(instance);
    }
    public void SetParent(Transform parent)
    {
        parentObj = parent;
    }
    
    public void InstanceAddToParent(GameObject instance)
    {
        Instantiate(instance, parentObj);
    }
}