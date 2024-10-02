using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]
public class Collection : ScriptableObject
{
    public IntData cash;
    public CollectablePanelBehaviour layoutObject;
    public List<Collectable> collectablesList;

    public void ReorderList()
    {
        collectablesList.Sort();
    }
    
    public void AddCollectable(Collectable obj)
    {
        collectablesList.Add(obj);
        ReorderList();
    }
    
    public void RemoveCollectable(Collectable obj)
    {
        collectablesList.Remove(obj);
        ReorderList();
    }
}
