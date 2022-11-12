using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public GameAction gameActionObj;
    public UnityEvent awakeEvent, raiseEvent;
    private TimeSpan timeSpanObj;
    
    private void Start()
    {
        gameActionObj.raiseNoArgs += Raise;
        textObj = GetComponent<TextMeshProUGUI>();
        awakeEvent.Invoke();
    }

    private void Raise()
    {
        raiseEvent.Invoke();
    }

    public void UpdateText(StringList stringListDataObj)
    {
        textObj.text = stringListDataObj.ReturnCurrentLine();
    }
    
    public void UpdateText(IntData intDataObj)
    {
        textObj.text = intDataObj.value.ToString();
    }

    public void UpdateText(string obj)
    {
        textObj.text = obj;
    }

    public void UpdateText(FloatData obj)
    {
        textObj.text = obj.value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateTextWithTime(FloatData obj)
    {
        timeSpanObj = TimeSpan.FromSeconds(obj.value);
        textObj.text = timeSpanObj.Minutes + ":" + timeSpanObj.Seconds;
    }
}