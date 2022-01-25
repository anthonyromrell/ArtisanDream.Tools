using System.Collections.Generic;
using UnityEngine;

public class PoolingBehaviour : MonoBehaviour
{
    public GameAction getPoolObjects;
    public KeyCode keyCodeOption;
    
    private List<GameObject> objList;
    private int i;
    
    private void Awake()
    {
        objList = new List<GameObject>();
        getPoolObjects.raise += Raise;
    }

    private void Raise(object obj)
    {
        var newObj = obj as GameObject;
        objList.Add(newObj);
    }

    private void OnDisable()
    {
        objList.Clear();
    }

    void Update()
    {
        if (!Input.GetKeyDown(keyCodeOption)) return;
        objList[i].SetActive(true);
        i++;
        if (i >= objList.Count)
            i = 0;
    }
}
