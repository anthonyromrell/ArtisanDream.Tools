using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents2D : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    public float delayTime = 0.01f;
    private WaitForSeconds waitObj;
    public bool canRepeat;
    public int repeatTimes = 10;

    private void Start()
    {
        waitObj = new WaitForSeconds(delayTime);
    }
     
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        yield return waitObj;
        triggerEnterEvent.Invoke();

        if (canRepeat)
        {
            var i = 0;
            while (i < repeatTimes)
            {
                yield return waitObj;
                triggerEnterRepeatEvent.Invoke();
                i++;
            }
        }

        triggerEnterEndEvent.Invoke();
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        triggerExitEvent.Invoke();
    }
}