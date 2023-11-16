using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUIBehaviour : MonoBehaviour
{
    public UnityEvent buttonEvent;
    public InventoryData inventoryDataObj;
    public InventoryUIButtonBehaviour inventoryUIPrefab;
    
    private void Start()
    {
        buttonEvent.Invoke();
    }

    private void AddItemsToUI(IEnumerable<IInventoryItem> items, bool isStoreItem = false)
    {
        foreach (var item in items)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            if (elementData == null) continue;

            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            elementData.ButtonObj.interactable = !item.Used;

            if (!isStoreItem) continue;
            var storeElementData = elementData as StoreUIButtonBehaviour;

            if (storeElementData == null || item is not IStoreItem storeItem) continue;
            storeElementData.StoreItemObj = storeItem;
            storeElementData.ToggleObj.isOn = storeItem.Purchased;
            storeElementData.PriceLabel.text = $"${storeItem.Price}";
            storeElementData.Cash = inventoryDataObj.cash;
        }
    }

    public void AddAllInventoryItemsToUI()
    {
        AddItemsToUI(inventoryDataObj.inventoryDataObjList);
    }
    
    public void AddAllStoreInventoryItemsToUI()
    {
        AddItemsToUI(inventoryDataObj.storeDataObjList, true);
    }
}