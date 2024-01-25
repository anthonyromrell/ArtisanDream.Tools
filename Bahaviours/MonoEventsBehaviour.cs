using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public float startHoldTime = 0.1f;
    private WaitForSeconds waitStartObj;
    public GameAction awakeAction, startAction;
    public UnityEvent awakeEvent, startEvent;
    
    protected virtual void Awake()
    {
        awakeEvent.Invoke();
        if (awakeAction != null) awakeAction.RaiseNoArgs();
        waitStartObj = new WaitForSeconds(startHoldTime);
    }

    private IEnumerator Start()
    {
        yield return waitStartObj;
        startEvent.Invoke();
        if (startAction != null) startAction.RaiseNoArgs();
    }
}