using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{
    private Image imageObj;
    private FloatData dataObj;
    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    public void UpdateWithFloatData()
    {
        imageObj.fillAmount = dataObj.Value;
    }
}