using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : MonoEventsBehaviour
{
    public UnityEvent triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    private WaitForSeconds waitEnterObj, waitRepeatObj;
    public float triggerHoldTime = 0.01f, repeatHoldTime = 0.01f;
    public bool canRepeat, canRepeatWithLimits;
    private bool repeat;
    public int repeatLimit = 10;

    protected override void Awake()
    {
        base.Awake();
        waitEnterObj = new WaitForSeconds(triggerHoldTime);
        waitRepeatObj = new WaitForSeconds(repeatHoldTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        repeat = true;
        yield return waitEnterObj;
        triggerEnterEvent.Invoke();
        
        if (canRepeatWithLimits)
        {
            var count = 0;
            while (repeat && count < repeatLimit)
            {
                yield return waitRepeatObj;
                triggerEnterRepeatEvent.Invoke();
                count++;
            }
        }
        
        if (canRepeat)
            while (repeat)
            {
                yield return waitRepeatObj;
                triggerEnterRepeatEvent.Invoke();
            }
        

        yield return waitEnterObj;
        triggerEnterEndEvent.Invoke();
    }
    

    private void OnTriggerExit(Collider other)
    {
        repeat = false;
        triggerExitEvent.Invoke();
    }
}