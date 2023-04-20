using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItemBehaviour : MonoBehaviour
{
    public InventoryItem inventoryItemObj;
    public InventoryData inventoryDataObj;
    public UnityEvent startEvent, triggerEnterEvent;

    private void Start()
    {
        startEvent.Invoke();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

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

    
}
