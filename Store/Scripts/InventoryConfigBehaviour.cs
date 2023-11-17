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
    
    public void AddAllInventoryItemsToUI()
    {
        foreach (var item in inventoryDataObj.inventoryDataObjList)
        {
            if (item is not { UsedOrPurchase: true }) continue;
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ConfigButton(item);
        }
    }

    public void AddAllStoreInventoryItemsToUI()
    {
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<StoreUIButtonBehaviour>();
            elementData.ConfigButton(item);
        }
    }

    public void AddPurchasedInventoryItemsPrefabsToScene()
    {
        var i = 0;
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            if (!item.UsedOrPurchase || item is not IInventoryItem storeItem ) continue;
            if (storeItem.GameActionObj == null || storeItem.GameArt == null);
            var element = Instantiate(storeItem.GameArt, transform);
            var elementData = element.GetComponent<InventoryPrefabItemBehaviour>();
            elementData.ConfigureGameObject(storeItem, i++);
        }
    }
}