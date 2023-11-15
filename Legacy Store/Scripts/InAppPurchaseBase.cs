using UnityEngine;

[CreateAssetMenu(fileName = "InAppPurchase", menuName = "Store/In App Purchasable")]
public class InAppPurchaseBase : ScriptableObject, ICanBePurchased
{
    [SerializeField] private int value;
    [SerializeField] private Sprite previewArt;

    public PurchaseType.Type ItemPurchaseType { get; set; }
    public Object Obj { get; set; }
    public string Name { get; set; }

    public Sprite PreviewArt
    {
        get => previewArt;
        set => previewArt = value;
    }

    public int Value
    {
        get => value;
        set => this.value = value;
    }

    public void OnEnable()
    {
        Name = name;
    }

    public void RaiseHandler(object obj)
    {
       
    }
}