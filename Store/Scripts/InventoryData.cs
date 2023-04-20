using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    public IntData cash;
    [SerializeField]private List<ScriptableObject> inventory;
    public List<IStoreItem> InventoryDataObj;
    
    private void OnEnable()
    {
        UpdateStoreItemsInventory();
    }

    public void AddToInventory(ScriptableObject obj)
    {
        inventory.Add(obj);
    }
    
    public void UpdateStoreItemsInventory()
    {
        InventoryDataObj = new List<IStoreItem>();
        foreach (var item in inventory)
        {
            if(item is IStoreItem storeItem)                                                                                                                                                                                                
                InventoryDataObj.Add(storeItem);
        }
    }
}
