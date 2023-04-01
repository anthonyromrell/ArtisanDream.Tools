using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StoreData : ScriptableObject
{
    public IntData cash;
    [SerializeField]private List<ScriptableObject> inventory;
    public List<IStoreItem> storeItemsInventory;
    
    private void OnEnable()
    {
        UpdateStoreItemsInventory();
    }

    public void UpdateStoreItemsInventory()
    {
        storeItemsInventory = new List<IStoreItem>();
        storeItemsInventory.Clear();
        foreach (var item in inventory)
        {
            if(item is IStoreItem storeItem)                                                                                                                                                                                                
                storeItemsInventory.Add(storeItem);
        }
    }
}
