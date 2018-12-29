using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InGamePurchase", menuName = "Store/In Game Purchasable")]
public class InGamePurchase : ScriptableObject, ICanBePurchased
{
    public Object Item;
    public Object Obj { get; set; }
    [SerializeField] private Sprite previewArt;
    public int UsageCount = 3;
    public int UsagePurchase = 10;
    public bool UnlimitedUse;
    [SerializeField] private int value;
    public bool Upgrade;
    public InGamePurchase UpgradeFrom;
    public GameAction GetInstanceLocation;
    private Transform location;

    public bool Perpetual;
    public bool Instanciatable;
    public UnityEvent OnCreate;

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
        for (var i = 0; i < UsageCount; i++)
        {
            if (Instanciatable && Item is GameObject)
            {
                Instantiate(Item);
            }
        }
    }
    
    public void CreateItemsOnParent()
    {
        for (var i = 0; i < UsageCount; i++)
        {
            if (Instanciatable && Item is GameObject)
            {
                Instantiate(Item, location);
            }
        }
    }
    
    public void CreateItemsAtLocation()
    {
        for (var i = 0; i < UsageCount; i++)
        {
            if (Instanciatable && Item is GameObject)
            {
                Instantiate(Item, location.position, Quaternion.identity);
            }
        }
    }

    public void CreateOnceAtLocation()
    {
        if (UsageCount > 0 || UnlimitedUse)
        {
            Instantiate(Item, location.position, Quaternion.identity);
        } 
    }
    
    public void CreateOnceAndParent()
    {
        if (UsageCount > 0 || UnlimitedUse)
        {
            Instantiate(Item, location);
        } 
    }

    public void Used()
    {
        if (!UnlimitedUse && UsageCount > 0)
        {
            UsageCount--;
        }
    }

    public void OnEnable()
    {
        Name = name;
        if (GetInstanceLocation != null) GetInstanceLocation.Raise += RaiseHandler;
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