using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject, IStoreItem, IInventoryItem
{
    [SerializeField] private int price;
    [SerializeField] private bool purchased;
    [SerializeField] private bool canUse;
    [SerializeField] private Sprite previewArt;
    [SerializeField] private int intLevel;
    [SerializeField] private float floatLevel; // Changed to float
    [SerializeField] private GameObject gameArt;
    [SerializeField] private bool used;
    [SerializeField] private GameAction gameActionObj;

    // IStoreItem and IInventoryItem Implementation
    public int Price { get => price; set => price = value; }
    public bool Purchased { get => purchased; set => purchased = value; }
    public bool CanUse { get => canUse; set => canUse = value; }
    public bool Used { get => used; set => used = value; }
    public int IntLevel { get => intLevel; set => intLevel = value; }
    public float FloatLevel { get => floatLevel; set => floatLevel = value; } // Corrected type
    public Sprite PreviewArt { get => previewArt; set => previewArt = value; }
    public GameObject GameArt { get => gameArt; set => gameArt = value; }
    public string Name
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