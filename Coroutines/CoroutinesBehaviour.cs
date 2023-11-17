using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutinesBehaviour : MonoEventsBehaviour
{
    public float seconds = 1f;
    public UnityEvent delayEvent, repeatEvent, endEvent;
    public GameAction delayAction, repeatAction, endAction;
    public bool canRun;
    public IntData counterNum;
    public int counterNumTemp;
    
    private WaitForSeconds waitForSecondsObj;
    private WaitForFixedUpdate waitForFixedUpdate;

    public float Seconds
    {
        get => seconds;
        set => seconds = value;
    }

    private bool CanRun
    {
        get => canRun;
        set => canRun = value;
    }

    protected override void Awake ()
    {
        base.Awake();
        waitForSecondsObj = new WaitForSeconds(Seconds);
        waitForFixedUpdate = new WaitForFixedUpdate();
        if (counterNum != null) counterNumTemp = counterNum.Value;
    }
    

    public void StartDelayCoroutine()
    {
        StartCoroutine(DelayCoroutine());
    }
    
    private IEnumerator DelayCoroutine()
    {
        yield return waitForSecondsObj;
        delayEvent.Invoke();
        delayAction.Raise();
    }
    
    public void StartRepeatSecondsCoroutine()
    {
        StartCoroutine(RepeatSecondsCoroutine());
    }

    private IEnumerator RepeatSecondsCoroutine()
    {
        CanRun = true;
        startEvent.Invoke();
        while (CanRun) 
        {
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
            repeatAction.Raise();
        }
        endEvent.Invoke();
        endAction.Raise();
    }
    
    public void StartRepeatCountDownCoroutine()
    {
        StartCoroutine(RepeatCountDownCoroutine());
    }

    private IEnumerator RepeatCountDownCoroutine()
    {
        startEvent.Invoke();
        while (counterNumTemp > 0) 
        {
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
            counterNumTemp--;
        }
        endEvent.Invoke();
    }
    
    private IEnumerator RepeatCountUpCoroutine()
    {
        var counterNumTemp = 0;
        startEvent.Invoke();
        while (counterNumTemp < counterNum.Value) 
        {
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
            counterNumTemp++;
        }
        endEvent.Invoke();
    }
    
    public void StartRepeatFixedCoroutine()
    {
        StartCoroutine(RepeatFixedCoroutine());
    }
    
    private IEnumerator RepeatFixedCoroutine()
    {
        CanRun = true;
        startEvent.Invoke();
        startAction.Raise();
        while (CanRun) 
        {
            yield return waitForFixedUpdate;
            repeatEvent.Invoke();
            repeatAction.Raise();
        }
        endEvent.Invoke();
        endAction.Raise();
    }
}