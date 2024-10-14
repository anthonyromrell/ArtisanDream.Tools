using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutinesBehaviour : MonoEventsBehaviour
{
    [SerializeField] private float seconds = 1f;
    public UnityEvent delayEvent, repeatEvent, endEvent;
    private bool canRun;
    public IntData counterNum;
    public int maxCounterNum = 3;
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
    // ...

    private void InvokeEventAndAction(UnityEvent unityEvent)
    {
        unityEvent?.Invoke();
        //gameAction.RaiseNoArgs();
    }

    private IEnumerator DelayCoroutine()
    {
        yield return waitForSecondsObj;
        InvokeEventAndAction(delayEvent);
    }

    // ...

    public void StartRepeatSecondsCoroutine()
    {
        if (canRun) return;
        canRun = true;
        StartCoroutine(RepeatSecondsCoroutine());
    }

    // ...

    private IEnumerator RepeatSecondsCoroutine()
    {
        InvokeEventAndAction(startEvent);
        while (canRun)
        {
            yield return waitForSecondsObj;
            InvokeEventAndAction(repeatEvent);
        }

        InvokeEventAndAction(endEvent);
    }

    private IEnumerator RepeatCountDownCoroutine()
    {
        counterNum.Value = maxCounterNum;
        startEvent.Invoke();
        while (counterNum.Value >= 0)
        {
            yield return waitForSecondsObj;
            repeatEvent.Invoke();
            counterNum.Value--;
        }

        endEvent.Invoke();
    }
}