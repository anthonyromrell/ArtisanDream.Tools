using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryConfigBehaviour : MonoBehaviour
{
    public UnityEvent buttonEvent;
    public InventoryData inventoryDataObj;
    public InventoryUIButtonBehaviour inventoryUIPrefab;

    private void Start()
    {
        buttonEvent.Invoke();
    }

    private void AddItemsToUI(List<IInventoryItem> items)
    {
        foreach (var item in items)
        {
            if (item is not { UsedOrPurchase: true }) continue;
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ConfigButton(item);
        }
    }
    
    private void AddItemsToUI(List<IStoreItem> items)
    {
        foreach (var item in items)
        {
            if (item is not { UsedOrPurchase: false }) continue;
            {
                var element = Instantiate(inventoryUIPrefab.gameObject, transform);
                var elementData = element.GetComponent<StoreUIButtonBehaviour>();
                elementData.ConfigButton(item);
            }
        }
    }
    

    public void AddAllInventoryItemsToUI()
    {
        AddItemsToUI(inventoryDataObj.inventoryDataObjList);
    }

    public void AddAllStoreInventoryItemsToUI()
    {
        AddItemsToUI(inventoryDataObj.storeDataObjList);
    }
    
    private int ConfigureGameObject(IInventoryItem item, int i)
    {
        if (item.GameActionObj == null || item.GameArt == null) return i;

        var element = Instantiate(item.GameArt, transform);
        var elementData = element.GetComponent<InventoryPrefabItemBehaviour>();
        if (elementData == null) return i;
        elementData.inventoryItemObj = item as InventoryItem;
        elementData.gameActionObj = item.GameActionObj;
        elementData.gameObject.transform.position = Vector3.left * ++i * -3;
        return i;
    }
    
    public void AddAllInventoryItemsPrefabsToScene()
    {
        var i = inventoryDataObj.inventoryDataObjList.Aggregate(0, (current, item) => ConfigureGameObject(item, current));
    }

    

    public void AddPurchasedInventoryItemsPrefabsToScene()
    {
        var i = 0;
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            if (!item.UsedOrPurchase || item is not IInventoryItem storeItem ) continue;
            i = ConfigureGameObject(storeItem, i);
        }
    }
}