using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "InGamePurchase", menuName = "Store/In Game Purchasable")]
public class InGamePurchase : ScriptableObject, ICanBePurchased
{
    [FormerlySerializedAs("Item")] public Object item;
    public Object Obj { get; set; }
    [SerializeField] private Sprite previewArt;
    [FormerlySerializedAs("UsageCount")] public int usageCount = 3;
    [FormerlySerializedAs("UsagePurchase")] public int usagePurchase = 10;
    [FormerlySerializedAs("UnlimitedUse")] public bool unlimitedUse;
    [SerializeField] private int value;
    [FormerlySerializedAs("Upgrade")] public bool upgrade;
    [FormerlySerializedAs("UpgradeFrom")] public InGamePurchase upgradeFrom;
    [FormerlySerializedAs("GetInstanceLocation")] public GameAction getInstanceLocation;
    private Transform location;

    [FormerlySerializedAs("Perpetual")] public bool perpetual;
    [FormerlySerializedAs("Instanciatable")] public bool instanciatable;
    [FormerlySerializedAs("OnCreate")] public UnityEvent onCreate;

    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public PurchaseType.Type ItemPurchaseType { get; set; }
    
    public string Name { get; set; }

    public Sprite PreviewArt
    {
        get => previewArt;
        set => previewArt = value;
    }

    public void CreateItems()
    {
        for (var i = 0; i < usageCount; i++)
        {
            if (instanciatable && item is GameObject)
            {
                Instantiate(item);
            }
        }
    }
    
    public void CreateItemsOnParent()
    {
        for (var i = 0; i < usageCount; i++)
        {
            if (instanciatable && item is GameObject)
            {
                Instantiate(item, location);
            }
        }
    }
    
    public void CreateItemsAtLocation()
    {
        for (var i = 0; i < usageCount; i++)
        {
            if (instanciatable && item is GameObject)
            {
                Instantiate(item, location.position, Quaternion.identity);
            }
        }
    }

    public void CreateOnceAtLocation()
    {
        if (usageCount > 0 || unlimitedUse)
        {
            Instantiate(item, location.position, Quaternion.identity);
        } 
    }
    
    public void CreateOnceAndParent()
    {
        if (usageCount > 0 || unlimitedUse)
        {
            Instantiate(item, location);
        } 
    }

    public void Used()
    {
        if (!unlimitedUse && usageCount > 0)
        {
            usageCount--;
        }
    }

    public void OnEnable()
    {
        Name = name;
        if (getInstanceLocation != null) getInstanceLocation.raise += RaiseHandler;
    }

    public void RaiseHandler (object obj)
    {
        location = obj as Transform;
    }
}

public interface ICanBePurchased
{
    PurchaseType.Type ItemPurchaseType { get; set; }
    Object Obj { get; set; }
    string Name { get; set; }
    Sprite PreviewArt { get; set; }
    int Value { get; set; }
    void OnEnable();
    void RaiseHandler(object obj);
}

public struct PurchaseType
{
    public enum Type
    {
        Consumable,
        NonConsumable,
        AutoRenewAbleSubscription,
        NonRenewingSubscription
    }
}