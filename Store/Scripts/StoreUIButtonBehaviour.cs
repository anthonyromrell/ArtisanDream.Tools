using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StoreUIButtonBehaviour : InventoryUIButtonBehaviour
{
    public UnityEvent purchaseEvent, noPurchaseEvent;
    public IntData Cash { get; set; }
    public Text PriceLabel { get; private set; }
    public Toggle ToggleObj { get; private set; }
    public IStoreItem StoreItemObj { get; set; }
    
    private void Awake()
    {
        ButtonObj = GetComponent<Button>();
        Label = ButtonObj.GetComponentInChildren<TextMeshProUGUI>();
        ToggleObj = GetComponentInChildren<Toggle>();
        PriceLabel = ToggleObj.GetComponentInChildren<Text>();
    }

    public void OnMouseDown()
    {
        RunButton();
    }

    private void RunButton()
    {
        if (StoreItemObj.Price <= Cash.value)
        {
            StoreItemObj.Purchased = true;
            StoreItemObj.CanUse = true;
            ToggleObj.isOn = true;
            Cash.UpdateValue(-StoreItemObj.Price);
            ButtonObj.interactable = false;
            purchaseEvent.Invoke();
        }
        else
        {
            noPurchaseEvent.Invoke();
        }
    }
}
