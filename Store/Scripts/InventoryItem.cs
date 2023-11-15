using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject, IStoreItem, IInventoryItem
{
    [SerializeField]private int price;
    [SerializeField]private bool purchased, canUse;
    [SerializeField]private Sprite previewArt;
    [SerializeField]private int intLevel;
    [SerializeField]private int floatLevel;
    [SerializeField]private GameObject gameArt;
    [SerializeField]private bool used;
    //private IInventoryItem inventoryImplementation;

    int IStoreItem.Price
    {
        get => price;
        set => price = value;
    }

    bool IStoreItem.Purchased
    {
        get => purchased;
        set => purchased = value;
    }

    public bool CanUse
    {
        get => canUse;
        set => canUse = value;
    }

    public bool Used
    {
        get => used;
        set => used = value;
    }

    public int IntLevel
    {
        get => intLevel;
        set => intLevel = value;
    }

    public int FloatLevel
    {
        get => floatLevel;
        set => floatLevel = value;
    }

    public Sprite PreviewArt
    {
        get => previewArt;
        set => previewArt = value;
    }

    Sprite IStoreItem.PreviewArt
    {
        get => previewArt;
        set => previewArt = value;
    }

    public GameObject GameArt
    {
        get => gameArt;
        set => gameArt = value;
    }

    public string Name { get; set; }

    private void OnEnable()
    {
        Name = name;
    }

    public Sprite GetSprite()
    {
        return previewArt;
    }
    
    public GameObject GetGameArt()
    {
        return GameArt;
    }
}
