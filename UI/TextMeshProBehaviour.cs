using System.Globalization;
using TMPro;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    private TimeSpan timeSpanObj;
    public GameAction gameActionObj;
    private int currentNum, tempDifference;
    private WaitForFixedUpdate waitObj;
    public UnityEvent awakeEvent, raiseEvent;
    protected void Start()
    {
        waitObj = new WaitForFixedUpdate();
        gameActionObj.RaiseNoArgs += Raise;
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
        textObj.text = intDataObj.Value.ToString();
    }

    public new void UpdateText(string obj)
    {
        textObj.text = obj;
    }

    public new void UpdateText(FloatData obj)
    {
        textObj.text = obj.Value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateTextWithTime(FloatData obj)
    {
        timeSpanObj = TimeSpan.FromSeconds(obj.Value);
        textObj.text = timeSpanObj.Minutes + ":" + timeSpanObj.Seconds;
    }
    
    public new void UpdateTextAsMoney (IntData obj)
    {
        textObj.text = obj.Value.ToString("C0");
    }

    public void StoreIntDataValue(IntData obj)
    {
        currentNum = obj.Value;
    }
    public void StartUpdateNumberCount(IntData obj)
    {
        tempDifference = currentNum - obj.Value;
        StartCoroutine(UpdateNumberCount(obj));
    }

    private IEnumerator UpdateNumberCount(IntData intData)
    {
        while (intData.Value != currentNum)
        {
            currentNum-=5;
            textObj.text = currentNum.ToString("C0");
            yield return waitObj;
        }
    }
}