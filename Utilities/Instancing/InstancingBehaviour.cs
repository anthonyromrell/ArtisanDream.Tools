using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class InstancingBehaviour : MonoBehaviour
{
    public Object collectionObj;
    public UnityEvent startEvent;
    private ICollectList collectList;
    private void Start()
    {
        collectList = (ICollectList) collectionObj;
        startEvent.Invoke();
    }
    
    public void InstanceAddToSelf(GameObject prefab)
    {
        var newInstance = Instantiate(prefab, transform);
    }
    
    public void InstanceFromCollection(GameObject prefab)
    {
        //collectList.CollectionList.ForEach(print);
        collectList.Index = 0;
        while (collectList.Index < collectList.CollectionList.Count)
        {
            var newInstance = Instantiate(prefab, transform);
            collectList.ConfigureInstance(newInstance);
            collectList.Index++;
        }
    }
}
