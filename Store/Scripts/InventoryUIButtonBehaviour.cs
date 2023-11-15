using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class InventoryUIButtonBehaviour : MonoBehaviour
{
    public UnityEvent buttonEvent;
    public Button ButtonObj { get; protected set; }
    public TextMeshProUGUI Label { get; protected set; }
    
    public InventoryItem InventoryItemObj { get; set; }

    private void Awake()
    {
        ButtonObj = GetComponent<Button>();
        Label = ButtonObj.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnMouseDown()
    {
        RunButton();
    }

    private void RunButton()
    {
        buttonEvent.Invoke();
        InventoryItemObj.Used = true;
    }
}
