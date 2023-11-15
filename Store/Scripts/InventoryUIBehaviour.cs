using UnityEngine;
using UnityEngine.Events;

public class InventoryUIBehaviour : MonoBehaviour
{
    public UnityEvent buttonEvent;
    public InventoryData inventoryDataObj;
    public InventoryUIButtonBehaviour inventoryUIPrefab;
    private StoreUIButtonBehaviour storeUIPrefab;
    
    private void Start()
    {
        buttonEvent.Invoke();
    }

    public void AddAllInventoryItemsToUI()
    {
        foreach (var item in inventoryDataObj.inventoryDataObjList)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            if (item.Used)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
    
    public void AddAllStoreInventoryItemsToUI()
    {
        storeUIPrefab = inventoryUIPrefab as StoreUIButtonBehaviour;
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<StoreUIButtonBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.StoreItemObj = item;
            elementData.Label.text = item.Name;
            elementData.ToggleObj.isOn = item.Purchased;
            elementData.PriceLabel.text = "$" + item.Price;
            elementData.Cash = inventoryDataObj.cash;
            if (item.Purchased)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
    
    public void AddAllPurchasedInventoryItemsToUI()
    {
        storeUIPrefab = inventoryUIPrefab as StoreUIButtonBehaviour;
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            if (!item.Purchased) continue;
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            if (!item.CanUse)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
    
    private void AddAllInventoryItemsToGame()
    {
        foreach (var item in inventoryDataObj.inventoryDataObjList)
        {
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            if (item.Used)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
    
    public void AddAllPurchasedInventoryItemsToGame()
    {
        storeUIPrefab = inventoryUIPrefab as StoreUIButtonBehaviour;
        foreach (var item in inventoryDataObj.storeDataObjList)
        {
            if (!item.Purchased) continue;
            var element = Instantiate(inventoryUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<InventoryUIButtonBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.Label.text = item.Name;
            if (!item.CanUse)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
}
