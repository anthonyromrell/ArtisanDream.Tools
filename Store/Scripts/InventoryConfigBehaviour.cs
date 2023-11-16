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

    private void AddItemsToUI<T>(List<T> items)
    {
        
        foreach (var item in items)
        {
            GameObject element = null;
            if (item is IInventoryItem { UsedOrPurchase: true })
            {
                element = Instantiate(inventoryUIPrefab.gameObject, transform);
            }
            
            if (item is IStoreItem { UsedOrPurchase: false } )
            {
                element = Instantiate(inventoryUIPrefab.gameObject, transform);
            }
            
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
            elementData.Label.text = inventoryItem.ThisName;
            elementData.ButtonObj.interactable = inventoryItem.UsedOrPurchase;
            elementData.InventoryItemObj = inventoryItem as InventoryItem;
            if(inventoryItem.GameActionObj != null)
                elementData.ButtonObj.onClick.AddListener(inventoryItem.Raise);
            else
            {
                elementData.ButtonObj.interactable = false;
            }
        }

        if (item is not IStoreItem storeItem) return;
        {
            var elementData = element.GetComponent<StoreUIButtonBehaviour>();
            if (elementData == null) return;
            elementData.ButtonObj.image.sprite = storeItem.PreviewArt;
            elementData.Label.text = storeItem.ThisName;
            elementData.ButtonObj.interactable = !storeItem.UsedOrPurchase;
            elementData.StoreItemObj = storeItem;
            elementData.ToggleObj.isOn = storeItem.UsedOrPurchase;
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