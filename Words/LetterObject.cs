using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterObject : MonoBehaviour
{
    public bool IsActive { get; set; }
    
    [HideInInspector] public IdBehaviour idBehaviour;
    [HideInInspector] public TextMeshProUGUI textMesh;
    [HideInInspector] public Image image;
    [HideInInspector] public BoxCollider boxCollider;
    [HideInInspector] public DraggableBehaviour draggableBehaviour;
    public GameActionAdvanced letterCompleted;
    public void Awake()
    {
        ConfigLetter();
    }

    public void ReturnLetter()
    {
        letterCompleted.Raise(this);
    }
    
    private void ConfigLetter ()
    {
        idBehaviour = gameObject.GetComponent<IdBehaviour>();
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        image = gameObject.GetComponentInChildren<Image>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        draggableBehaviour = gameObject.GetComponent<DraggableBehaviour>();
    }
}
