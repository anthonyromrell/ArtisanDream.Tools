using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehaviour : MonoBehaviour
{
    private Image imageObj;
    public GameAction updateAction;
    public UnityEvent updateImageEvent;
    
    private void Start()
    {
        imageObj = GetComponent<Image>();
        updateAction.raiseNoArgs += OnUpdate;
    }

    public void OnUpdate()
    {
        updateImageEvent.Invoke();
    }

    public void UpdateWithFloatData(FloatData dataObj)
    {
        imageObj.fillAmount = dataObj.value;
    }
}