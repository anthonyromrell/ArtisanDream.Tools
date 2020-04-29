using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class InstancingBehaviour : MonoBehaviour
{
    public IntData indexer;
    public Object collectionObj;
    public UnityEvent startEvent;
    private ICollectList collectList;
    public Transform startPoint, targetPoint, prefabObj;
    //MUST SPLIT AND REFACTOR
    private void Start()
    {
        if (collectionObj != null) collectList = (ICollectList) collectionObj;
        startEvent.Invoke();
    }
    
    public void InstanceAddToSelf(GameObject prefab)
    {
        var newInstance = Instantiate(prefab, transform);
    }
    
    public void InstanceAtThisTransform(GameObject prefab)
    {
        var newInstance = Instantiate(prefab, transform.position, Quaternion.identity);
        newInstance.transform.LookAt(targetPoint.position);
    }

    public void InstanceUsingVars()
    {
        var newInstance = Instantiate(prefabObj, startPoint.position, Quaternion.identity);
        newInstance.transform.LookAt(targetPoint.position);
    }
    
    public void InstanceAddToSelfCount(GameObject prefab)
    {
        for (var i = 0; i < indexer.value; i++)
        {
            var newInstance = Instantiate(prefab, transform);
            newInstance.name = i.ToString();
        }
    }
    
    public void InstanceFromCollection(GameObject prefab)
    {
        collectList.Index = 0;
        while (collectList.Index < collectList.CollectionList.Count)
        {
            var newInstance = Instantiate(prefab, transform);
            collectList.ConfigureInstance(newInstance);
            collectList.Index++;
        }
    }
}
