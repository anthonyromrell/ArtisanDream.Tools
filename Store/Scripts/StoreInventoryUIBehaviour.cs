using UnityEngine;
//place on a UI Panel
public class StoreInventoryUIBehaviour : InventoryUIBehaviour
{
    private StoreUIButtonBehaviour storeUIPrefab;
    private void Start()
    {
        AddAllStoreInventoryItemsToUI();
    }

    private void AddAllStoreInventoryItemsToUI()
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
            elementData.cash = inventoryDataObj.cash;
            if (item.Purchased)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
}
