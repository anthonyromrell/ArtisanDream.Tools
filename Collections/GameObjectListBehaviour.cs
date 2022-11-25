using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectListBehaviour : MonoBehaviour
{
    public GameAction getFromAddAction;
    private void Start()
    {
        getFromAddAction.raise += AddObj;
    }

    private void AddObj(object obj)
    {
        AddToLIst(obj as GameObject);
    }

    public List<GameObject> objects;

    public void AddToLIst(GameObject obj)
    {
        objects.Add(obj);
    }

    public void RemoveAndDestroyFirst()
    {
        var obj = objects[0];
        objects.Remove(obj);
        Destroy(obj);
    }
}
