using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents2D : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    public float delayTimeStart = 0.01f, delayTimeHold = 0.01f, delayTimeEnd = 0.01f;
    private WaitForSeconds waitObjStart, waitObjHold, waitObjEnd;
    public bool canRepeat;
    public int repeatTimes = 10;

    private void Start()
    {
        waitObjStart = new WaitForSeconds(delayTimeStart);
        waitObjHold = new WaitForSeconds(delayTimeHold);
        waitObjEnd = new WaitForSeconds(delayTimeEnd);
    }
     
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        yield return waitObjStart;
        triggerEnterEvent.Invoke();

        if (canRepeat)
        {
            var i = 0;
            while (i < repeatTimes)
            {
                yield return waitObjHold;
                triggerEnterRepeatEvent.Invoke();
                i++;
            }
        }

        yield return waitObjEnd;
        triggerEnterEndEvent.Invoke();
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        triggerExitEvent.Invoke();
    }
}