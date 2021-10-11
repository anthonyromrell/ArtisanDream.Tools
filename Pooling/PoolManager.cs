using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> pool;
    private int i;
    
    public void UseNext()
    {
        if (pool.Capacity > 0)
        {
            pool[i].SetActive(true);
            i++;
        }
        
        if (i == pool.Count)
        {
            i = 0;
        }
    }
}
