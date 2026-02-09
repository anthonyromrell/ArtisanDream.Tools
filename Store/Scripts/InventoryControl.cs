using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public InventoryData inventoryDataObj;
    public InventoryItem inventoryItemObj;

    private void OnMouseDown()
    {
        inventoryDataObj.RemoveFromInventory(inventoryItemObj);
        gameObject.SetActive(false);
    }
}