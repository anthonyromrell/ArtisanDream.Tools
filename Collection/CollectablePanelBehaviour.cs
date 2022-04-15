using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CollectablePanelBehaviour : MonoBehaviour
{
    private Image image;
    private Text label, buttonLabel;
    private Button button;
    [HideInInspector] public Collectable collectable;
    [HideInInspector] public IntData cash;
    private UnityAction collect;
    public GameAction checkCollection;
    private void Awake()
    {
        var images = GetComponentsInChildren<Image>();
        image = images[1];
        label = GetComponentInChildren<Text>();
        button = GetComponentInChildren<Button>();
        buttonLabel = button.GetComponentInChildren<Text>();
        collect += CollectAction;
        checkCollection.RaiseNoArgs += CheckButton;
        button.onClick.AddListener(collect);
    }
    
    private void Start()
    {
        ConfigPanel();
    }
    
    private void ConfigPanel ()
    {
        image.sprite = collectable.art;
        label.text = collectable.name;
        buttonLabel.text = $"Buy ${collectable.price}";
        CheckButton();
    }

    private void CheckButton()
    {
        button.gameObject.SetActive(true);
        button.interactable = cash.Value >= collectable.price;
        button.gameObject.SetActive(!collectable.collected);
    }

    private void CollectAction()
    {
        collectable.collected = true;
        cash.UpdateValueZeroCheck(-collectable.price);
        checkCollection.RaiseNoArgs.Invoke();
    }
}
