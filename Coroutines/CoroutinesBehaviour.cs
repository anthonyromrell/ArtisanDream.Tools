using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutinesBehaviour : MonoBehaviour
{
    public float seconds = 1f;
    public UnityEvent startCoroutineEvent, startEvent, delayEvent, repeatEvent, endEvent;
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

    public bool CanRun
    {
        get => canRun;
        set => canRun = value;
    }

    private void Awake ()
    {
        waitForSecondsObj = new WaitForSeconds(Seconds);
        waitForFixedUpdate = new WaitForFixedUpdate();
    }

    private void Start()
    {
        startCoroutineEvent.Invoke();
    }

    public void StartDelayCoroutine()
    {
        StartCoroutine(DelayCoroutine());
    }
    
    private IEnumerator DelayCoroutine()
    {
        yield return waitForSecondsObj;
        delayEvent.Invoke();
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
        }
        endEvent.Invoke();
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
    
    public void StartRepeatFixedCoroutine()
    {
        StartCoroutine(RepeatFixedCoroutine());
    }
    
    private IEnumerator RepeatFixedCoroutine()
    {
        CanRun = true;
        startEvent.Invoke();
        while (CanRun) 
        {
            yield return waitForFixedUpdate;
            repeatEvent.Invoke();
        }
        endEvent.Invoke();
    }
}