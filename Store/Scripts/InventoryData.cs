using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    public IntData cash;
    [SerializeField]private List<ScriptableObject> inventory;
    public List<IInventoryItem> inventoryDataObjList;
    public List<IStoreItem> storeDataObjList;

    public InventoryData(List<IInventoryItem> inventoryDataObjList, List<IStoreItem> storeDataObjList)
    {
        this.inventoryDataObjList = inventoryDataObjList;
        this.storeDataObjList = storeDataObjList;
    }

    private void OnEnable()
    {
        UpdateStoreItemsInventory();
        UpdateItemsInventory();
    }

    public void AddToInventory(ScriptableObject obj)
    {
        inventory.Add(obj);
    }

    public void ClearInventory()
    {
        inventory.Clear();
        inventoryDataObjList.Clear();
        storeDataObjList.Clear();
    }
    public void UpdateStoreItemsInventory()
    {
        storeDataObjList = new List<IStoreItem>();
        foreach (var item in inventory)
        {
            if(item is IStoreItem inventoryItem)                                                                                                                                                                                                
                storeDataObjList.Add(inventoryItem);
        }
    }
    
    public void UpdateItemsInventory()
    {
        inventoryDataObjList = new List<IInventoryItem>();
        foreach (var item in inventory)
        {
            if(item is IInventoryItem inventoryItem)                                                                                                                                                                                                
                inventoryDataObjList.Add(inventoryItem);
        }
    }
}
