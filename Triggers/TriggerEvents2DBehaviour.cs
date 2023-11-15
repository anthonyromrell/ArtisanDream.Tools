using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents2DBehaviour : MonoEventsBehaviour
{
    public UnityEvent triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    private WaitForSeconds waitForTriggerEnterObj, waitForTriggerRepeatObj;
    public float triggerHoldTime = 0.01f, repeatHoldTime = 0.01f, exitHoldTime = 0.01f;
    public bool canRepeat;
    public int repeatTimes = 10;
     
    protected override void Awake()
    {
        base.Awake();
        waitForTriggerEnterObj = new WaitForSeconds(triggerHoldTime);
        waitForTriggerRepeatObj = new WaitForSeconds(repeatHoldTime);
    }
    
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent.Invoke();

        if (canRepeat)
        {
            var i = 0;
            while (i < repeatTimes)
            {
                yield return waitForTriggerEnterObj;
                i++;
                triggerEnterRepeatEvent.Invoke();
            }
        }
        yield return waitForTriggerRepeatObj;
        triggerEnterEndEvent.Invoke();
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        triggerExitEvent.Invoke();
    }
}