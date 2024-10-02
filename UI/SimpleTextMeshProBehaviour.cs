using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }
    
    public void UpdateWithIntData()
    {
        textObj.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}