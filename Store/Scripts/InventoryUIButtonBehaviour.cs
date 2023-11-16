using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUIButtonBehaviour : MonoBehaviour
{
    public Button ButtonObj { get; protected set; }
    public TextMeshProUGUI Label { get; protected set; }
    
    public InventoryItem InventoryItemObj { get; set; }

    protected virtual void Awake()
    {
        ButtonObj = GetComponent<Button>();
        Label = ButtonObj.GetComponentInChildren<TextMeshProUGUI>();
     
        if (ButtonObj != null)
        {
            ButtonObj.onClick.AddListener(HandleButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject", this);
        }
    }

    private void HandleButtonClick()
    {
        if (InventoryItemObj == null) return;
        InventoryItemObj.Used = true;
        ButtonObj.interactable = false;
    }
}