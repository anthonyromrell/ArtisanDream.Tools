using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject, IStoreItem, IInventoryItem
{
    [SerializeField] private int price;
    //[SerializeField] private bool purchased;
    [SerializeField] private bool own;
    [SerializeField] private Sprite previewArt;
    [SerializeField] private int intLevel;
    [SerializeField] private float floatLevel; // Changed to float
    [SerializeField] private GameObject gameArt;
    [SerializeField] private bool usedOrPurchase;
    [SerializeField] private GameAction gameActionObj;

    // IStoreItem and IInventoryItem Implementation
    public int Price { get => price; set => price = value; }
    //public bool Purchased { get => purchased; set => purchased = value; }
    public bool Own { get => own; set => own = value; }
    public bool UsedOrPurchase { get => usedOrPurchase; set => usedOrPurchase = value; }
    public int IntLevel { get => intLevel; set => intLevel = value; }
    public float FloatLevel { get => floatLevel; set => floatLevel = value; } // Corrected type
    public Sprite PreviewArt { get => previewArt; set => previewArt = value; }
    public GameObject GameArt { get => gameArt; set => gameArt = value; }
    public string ThisName
    {
        get => name; // Directly return the scriptable object's name
        set => name = value;
    }

    public GameAction GameActionObj
    {
        get => gameActionObj;
        set => gameActionObj = value;
    }

    public void Raise()
    {
        if (gameActionObj != null) gameActionObj.Raise();
    }
}