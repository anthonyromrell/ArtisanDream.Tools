using UnityEngine;
using UnityEngine.Events;

public class InventoryControl : MonoBehaviour
{
    public InventoryData inventoryDataObj;
    public InventoryItem inventoryItemObj;
    public UnityEvent onMouseDownEvent;
    public bool active;
    private void OnMouseDown()
    {
        onMouseDownEvent.Invoke();
    }
    
    //remove inventory item and return it to store
    public void RemoveFromInventory()
    {
        inventoryDataObj.RemoveFromInventory(inventoryItemObj);
        gameObject.SetActive(active);
    }
    
    //Add inventory item to inventory and remove it from store
    public void AddToInventory()
    {
        inventoryDataObj.AddToInventory(inventoryItemObj);
        gameObject.SetActive(active);
    }
}