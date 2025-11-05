using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehaviour : MonoBehaviour
{
    private Image imageObj;
    public GameAction updateAction;
    public UnityEvent startEvent, updateImageEvent;
    
    private void Start()
    {
        imageObj = GetComponent<Image>(); 
        if (updateAction != null) updateAction.RaiseNoArgs += OnUpdate;
        startEvent.Invoke();
    }

    public void OnUpdate()
    {
        updateImageEvent.Invoke();
    }

    public void UpdateWithFloatData(FloatData dataObj)
    {
        imageObj.fillAmount = dataObj.Value;
    }
    
    public void ChangeImageColor(ScriptableObject c)
    {
        var colorData = c as ColorData;
        if (colorData != null) imageObj.color = colorData.Value;
    }
}