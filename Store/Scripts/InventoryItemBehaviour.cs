using UnityEngine;
using UnityEngine.Events;

public class InventoryItemBehaviour : ColliderBehaviour
{
    public InventoryItem inventoryItemObj;
    public InventoryData inventoryDataObj;
    

    public void Config2DAsset()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = inventoryItemObj.GetSprite();
    }
    
    public void Config3DAsset()
    {
        
    }

    public void AddToInventory()
    {
        inventoryDataObj.AddToInventory(inventoryItemObj);
    }

    public void UseItem()
    {
        //
    }
}