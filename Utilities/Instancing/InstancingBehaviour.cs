using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InstancingBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("Indexer")] public IntData indexer;
    [FormerlySerializedAs("StartEvent")] public UnityEvent startEvent;
    [FormerlySerializedAs("SpawnPoint")] public Transform spawnPoint;
    [FormerlySerializedAs("TargetPoint")] public Transform targetPoint;
    [FormerlySerializedAs("PrefabObj")] public Transform prefabObj;

    private void Start()
    {
        startEvent.Invoke();
    }

    public void InstantiateGameObject(GameObject prefab, Transform parent)
    {
        Instantiate(prefab, parent);
    }

    public void InstantiateAtPosition(GameObject prefab)
    {
        var newInstance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        newInstance.transform.LookAt(targetPoint.position);
    }

    public void InstantiateUsingPrefab()
    {
        if (prefabObj == null) return;
        var newInstance = Instantiate(prefabObj, spawnPoint.position, Quaternion.identity);
        newInstance.transform.LookAt(targetPoint.position);
    }

    public void InstantiateMultiple(GameObject prefab)
    {
        for (var i = 0; i < indexer.Value; i++)
        {
            var newInstance = Instantiate(prefab, spawnPoint);
            newInstance.name = i.ToString();
        }
    }
}