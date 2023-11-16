using UnityEngine;

public class InventoryItemBehaviour : ColliderBehaviour
{
    public GameAction gameActionObj;
    public InventoryItem inventoryItemObj;
    
    protected override void Start()
    {
        base.Start();
        inventoryItemObj.GameActionObj = gameActionObj;
        triggerEnterEvent.AddListener(UseItem);
    }

    private void UseItem()
    {
        if (inventoryItemObj == null) return;
        inventoryItemObj.UsedOrPurchase = false;
        gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        gameActionObj.Raise();
    }
}