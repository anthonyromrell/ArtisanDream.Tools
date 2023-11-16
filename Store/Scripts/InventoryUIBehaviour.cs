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

    private void AddItemsToUI(List<IInventoryItem> items)
    {
        foreach (var item in items)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name; 
            elementData.ButtonObj.interactable = !item.Used;
        }
    }
    
    private void AddItemsToUI (List<IStoreItem> items)
    {
        foreach (var item in items)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<StoreUIButtonBehaviour>();

            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            elementData.ButtonObj.interactable = !item.Purchased;
            elementData.StoreItemObj = item;
            elementData.ToggleObj.isOn = item.Purchased;
            elementData.PriceLabel.text = $"${item.Price}";
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