using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public void Initialize(GameObject prefab, int poolSize, Transform parent)
    {
        this.prefab = prefab;
        this.poolSize = poolSize;

        // Fill the pool with deactivated instances of the prefab
        for (int i = 0; i < poolSize; i++)
        {
            var instance = Instantiate(prefab, parent);
            instance.SetActive(false);
            pool.Enqueue(instance);
        }
    }

    public T GetObject<T>() where T : MonoBehaviour
    {
        if (pool.Count == 0)
        {
            AddObjects(poolSize);
        }

        var obj = pool.Dequeue();
        obj.SetActive(true);
        return obj.GetComponent<T>();
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public void DeactivateAll()
    {
        foreach (var obj in pool)
        {
            obj.SetActive(false);
        }
    }

    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(prefab, transform);
            instance.SetActive(false);
            pool.Enqueue(instance);
        }
    }
}