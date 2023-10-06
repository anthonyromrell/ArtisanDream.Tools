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
    public int maxCounterNum = 3;
    
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
        counterNum.value = maxCounterNum;
        startEvent.Invoke();
        while (counterNum.value >= 0) 
        {
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
            counterNum.value--;
        }
        endEvent.Invoke();
    }
    
    private IEnumerator RepeatCountUpCoroutine()
    {
        counterNumTemp = 0;
        startEvent.Invoke();
        while (counterNumTemp < counterNum.value) 
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