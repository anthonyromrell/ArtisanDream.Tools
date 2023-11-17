using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InstancingBehaviour : MonoBehaviour
{
    public Object collectionObj;
    public UnityEvent startEvent;
    private ICollectList<Object> collectList; 

    private void Start()
    {
        collectList = collectionObj as ICollectList<Object>;
        startEvent?.Invoke();
    }
    
    public void InstantiateAtTransform(GameObject prefab, Transform location, Transform lookAtTarget = null)
    {
        if (prefab == null || location == null) return;

        var newInstance = Instantiate(prefab, location.position, Quaternion.identity);
        if (lookAtTarget != null)
        {
            newInstance.transform.LookAt(lookAtTarget.position);
        }
    }
    
    public void InstantiateMultiple(GameObject prefab, int count, Transform parent = null)
    {
        if (prefab == null) return;

        for (var i = 0; i < count; i++)
        {
            var newInstance = Instantiate(prefab, parent ? parent.position : Vector3.zero, Quaternion.identity, parent);
            newInstance.name = prefab.name + "_" + i;
        }
    }
    
    public void InstantiateFromCollection(GameObject prefab)
    {
        if (prefab == null || collectList?.CollectionList == null) return;

        foreach (var newInstance in collectList.CollectionList.Select(item => Instantiate(prefab, transform)))
        {
            collectList.ConfigureInstance(newInstance);
        }
    }
}