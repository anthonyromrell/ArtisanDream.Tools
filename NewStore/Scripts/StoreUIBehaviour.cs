using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StoreUIBehaviour : MonoBehaviour
{
    public UnityEvent purchaseEvent, noPurchaseEvent;
    public IntData Cash { get; set; }
    public Button ButtonObj { get; set; }
    public TextMeshProUGUI Label { get; set; }
    public Text PriceLabel { get; set; }
    public Toggle ToggleObj { get; set; }
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
        if (StoreItemObj.Price <= Cash.value)
        {
            StoreItemObj.Purchased = true;
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
