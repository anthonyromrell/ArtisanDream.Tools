using UnityEngine;

public class InventoryPrefabItemBehaviour : ColliderBehaviour
{
    public GameAction gameActionObj;
    public InventoryItem inventoryItemObj;
    
    protected override void Start()
    {
        base.Start();
        inventoryItemObj.GameActionObj = gameActionObj;
        triggerEnterEvent.AddListener(UseItem);
    }

    public int ConfigureGameObject(IInventoryItem item, int i)
    {
        if (item.GameActionObj == null || item.GameArt == null) return i;
        inventoryItemObj = item as InventoryItem;
        gameActionObj = item.GameActionObj;
        gameObject.transform.position = Vector3.left * i * -2;
        return i;
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
        gameActionObj.RaiseNoArgs();
    }
}