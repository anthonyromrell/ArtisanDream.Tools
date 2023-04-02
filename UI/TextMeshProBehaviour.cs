using System.Globalization;
using TMPro;
using UnityEngine;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProBehaviour : TextBehaviour
{
    private TextMeshProUGUI textObj;
    private TimeSpan timeSpanObj;

    protected override void Start()
    {
        gameActionObj.raiseNoArgs += Raise;
        textObj = GetComponent<TextMeshProUGUI>();
        awakeEvent.Invoke();
    }

    private void Raise()
    {
        raiseEvent.Invoke();
    }

    public new void UpdateText(StringList stringListDataObj)
    {
        textObj.text = stringListDataObj.ReturnCurrentLine();
    }
    
    public new void UpdateText(IntData intDataObj)
    {
        textObj.text = intDataObj.value.ToString();
    }

    public new void UpdateText(string obj)
    {
        textObj.text = obj;
    }

    public new void UpdateText(FloatData obj)
    {
        textObj.text = obj.value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateTextWithTime(FloatData obj)
    {
        timeSpanObj = TimeSpan.FromSeconds(obj.value);
        textObj.text = timeSpanObj.Minutes + ":" + timeSpanObj.Seconds;
    }
    
    public new void UpdateTextAsMoney (IntData obj)
    {
        textObj.text = "$"+obj.value;
    }
}