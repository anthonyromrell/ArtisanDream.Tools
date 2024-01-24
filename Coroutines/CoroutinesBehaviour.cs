using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutinesBehaviour : MonoEventsBehaviour
{
    [SerializeField] private float seconds = 1f;
    public UnityEvent delayEvent, repeatEvent, endEvent;
    public GameAction delayAction, repeatAction, endAction;
    private bool canRun;
    public IntData counterNum;
    
    private WaitForSeconds waitForSecondsObj;
    private WaitForFixedUpdate waitForFixedUpdate;

    public float Seconds
    {
        get => seconds;
        set
        {
            if (Mathf.Approximately(seconds, value)) return;
            seconds = value;
            waitForSecondsObj = new WaitForSeconds(seconds);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        waitForSecondsObj = new WaitForSeconds(Seconds);
        waitForFixedUpdate = new WaitForFixedUpdate();
    }

    // ... Other methods ...

    private void InvokeEventAndAction(UnityEvent unityEvent, GameAction gameAction)
    {
        unityEvent?.Invoke();
        gameAction.Raise();
    }

    private IEnumerator DelayCoroutine()
    {
        yield return waitForSecondsObj;
        InvokeEventAndAction(delayEvent, delayAction);
    }

    // ... Similar changes for other coroutines ...

    public void StartRepeatSecondsCoroutine()
    {
        if (canRun) return;
        canRun = true;
        StartCoroutine(RepeatSecondsCoroutine());
    }

    // ... Similar changes for starting other coroutines ...

    private IEnumerator RepeatSecondsCoroutine()
    {
        InvokeEventAndAction(startEvent, startAction);
        while (canRun) 
        {
            yield return waitForSecondsObj;
            InvokeEventAndAction(repeatEvent, repeatAction);
        }
        InvokeEventAndAction(endEvent, endAction);
    }

    // ... Similar structure for other coroutine methods ...
    
}