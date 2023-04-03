using UnityEngine;
//place on a UI Panel
public class InventoryUIBehaviour : MonoBehaviour
{
    public StoreData storeDataObj;
    public StoreUIBehaviour storeUIPrefab;
    private void Start()
    {
        foreach (var item in storeDataObj.storeItemsInventory)
        {
            var element = Instantiate(storeUIPrefab.gameObject, transform);
            var elementData = element.GetComponent<StoreUIBehaviour>();
            elementData.ButtonObj.image.sprite = item.PreviewArt;
            elementData.StoreItemObj = item;
            elementData.Label.text = item.Name;
            elementData.ToggleObj.isOn = item.Purchased;
            elementData.PriceLabel.text = "$"+item.Price;
            elementData.Cash = storeDataObj.cash;
            if (item.Purchased)
            {
                elementData.ButtonObj.interactable = false;
            }
        }
    }
}
