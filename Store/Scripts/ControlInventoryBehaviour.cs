

public class ControlInventoryBehaviour : ColliderBehaviour
{
    public InventoryData inventoryDataObj;
    
    public void ClearInventory ()
    {
        inventoryDataObj.ClearInventory();
    }
}
