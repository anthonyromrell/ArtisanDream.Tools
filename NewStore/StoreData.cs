using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StoreData : ScriptableObject
{
    public List<ScriptableObject> inventory;
    private List<IStoreItem> storeItemsInventory;

    private void OnEnable()
    {
        UpdateStoreItemsInventory();
    }

    public void UpdateStoreItemsInventory()
    {
        storeItemsInventory.Clear();
        foreach (var item in inventory)
        {
            if(item is IStoreItem storeItem)                                                                                                                                                                                                
                storeItemsInventory.Add(storeItem);
        }
    }
}
