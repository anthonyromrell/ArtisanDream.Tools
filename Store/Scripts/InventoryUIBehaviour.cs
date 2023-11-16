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

    private void AddItemsToUI<T>(List<T> items)
    {
        foreach (var item in items)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            ConfigureElement(element, item);
        }
    }

    private void ConfigureElement<T>(GameObject element, T item)
    {
        if (item is IInventoryItem inventoryItem)
        {
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            if (elementData == null) return;

            elementData.ButtonObj.image.sprite = inventoryItem.PreviewArt;
            elementData.Label.text = inventoryItem.Name;
            elementData.ButtonObj.interactable = !inventoryItem.Used;
        }

        if (item is not IStoreItem storeItem) return;
        {
            var elementData = element.GetComponent<StoreUIButtonBehaviour>();
            if (elementData == null) return;

            elementData.ButtonObj.image.sprite = storeItem.PreviewArt;
            elementData.Label.text = storeItem.Name;
            elementData.ButtonObj.interactable = !storeItem.Purchased;
            elementData.StoreItemObj = storeItem;
            elementData.ToggleObj.isOn = storeItem.Purchased;
            elementData.PriceLabel.text = $"${storeItem.Price}";
            elementData.cash = inventoryDataObj.cash;
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
}