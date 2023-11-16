using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InventoryData", menuName = "Store/InventoryData")]
public class InventoryData : ScriptableObject
{
    public IntData cash;
    [SerializeField] private List<ScriptableObject> inventory;
    public readonly List<IInventoryItem> inventoryDataObjList = new List<IInventoryItem>();
    public readonly List<IStoreItem> storeDataObjList = new List<IStoreItem>();

    private void OnEnable()
    {
        SynchronizeInventory();
    }

    public void AddToInventory(ScriptableObject obj)
    {
        if (!inventory.Contains(obj))
        {
            inventory.Add(obj);
            SynchronizeInventory();
        }
    }

    public void ClearInventory()
    {
        inventory.Clear();
        SynchronizeInventory();
    }

    private void SynchronizeInventory()
    {
        inventoryDataObjList.Clear();
        storeDataObjList.Clear();

        foreach (var item in inventory)
        {
            if (item is IInventoryItem inventoryItem)
                inventoryDataObjList.Add(inventoryItem);
            if (item is IStoreItem storeItem)
                storeDataObjList.Add(storeItem);
        }
    }
}