using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIButtonBehaviour : MonoBehaviour
{
    public Button ButtonObj { get; private set; }
    public TextMeshProUGUI Label { get; private set; }
    
    public InventoryItem InventoryItemObj { get; set; }

    protected virtual void Awake()
    {
        ButtonObj = GetComponent<Button>();
        Label = ButtonObj.GetComponentInChildren<TextMeshProUGUI>();
     
        if (ButtonObj != null)
        {
            ButtonObj.onClick.AddListener(HandleButtonClick);
        }
    }

    public void ConfigButton(IInventoryItem inventoryItem)
    {
        ButtonObj.image.sprite = inventoryItem.PreviewArt;
        Label.text = inventoryItem.ThisName;
        ButtonObj.interactable = inventoryItem.UsedOrPurchase;
        InventoryItemObj = inventoryItem as InventoryItem;
        if(inventoryItem.GameActionObj != null)
            ButtonObj.onClick.AddListener(inventoryItem.Raise);
        else
        {
            ButtonObj.interactable = false;
        }
    }

    private void HandleButtonClick()
    {
        if (InventoryItemObj == null) return;
        InventoryItemObj.UsedOrPurchase = false;
        ButtonObj.interactable = false;
    }
}