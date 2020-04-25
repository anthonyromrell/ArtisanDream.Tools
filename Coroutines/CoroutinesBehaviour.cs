using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutinesBehaviour : MonoBehaviour
{
    public float seconds = 1f;
    public UnityEvent startEvent, delayEvent, repeatEvent, endEvent;
    private WaitForSeconds waitForSecondsObj;
    private WaitForFixedUpdate waitForFixedUpdate;
    public bool canRun;

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

    public void Awake ()
    {
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
            print("repeat");
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
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