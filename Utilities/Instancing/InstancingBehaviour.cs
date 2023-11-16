using UnityEngine;
using UnityEngine.Events;

public class InstancingBehaviour : MonoBehaviour
{
    public IntData indexer;
    public Object collectionObj;
    public UnityEvent startEvent;
    private ICollectList<Object> collectList; // Specify the type for ICollectList
    public Transform startPoint, targetPoint, prefabObj;

    private void Start()
    {
        var list = collectionObj as ICollectList<Object>;
        if (list != null) // Specify the type for ICollectList
        {
            collectList = list;
        }
        startEvent.Invoke();
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

    public void InstantiateMultiple(GameObject prefab, int count)
    {
        if (prefab == null) return;

        for (var i = 0; i < count; i++)
        {
            var newInstance = Instantiate(prefab, transform);
            newInstance.name = i.ToString();
        }
    }

    public void InstantiateFromCollection(GameObject prefab)
    {
        if (prefab == null || collectList?.CollectionList == null) return;

        foreach (var item in collectList.CollectionList)
        {
            var newInstance = Instantiate(prefab, transform);
            collectList.ConfigureInstance(newInstance);
        }
    }
}
