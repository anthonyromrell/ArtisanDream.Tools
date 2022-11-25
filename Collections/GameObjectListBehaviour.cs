using System.Collections.Generic;
using UnityEngine;

public class GameObjectListBehaviour : MonoBehaviour
{
    public GameAction getFromAddAction;
    public List<GameObject> objects;
    
    private void Start()
    {
        getFromAddAction.raise += AddObj;
    }

    private void AddObj(object obj)
    {
        AddToLIst(obj as GameObject);
    }
    
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
