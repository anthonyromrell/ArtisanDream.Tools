using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public float startHoldTime = 0.1f;
    private WaitForSeconds waitStartObj;
    public UnityEvent awakeEvent, startEvent;
    
    protected virtual void Awake()
    {
        awakeEvent.Invoke();
        waitStartObj = new WaitForSeconds(startHoldTime);
    }

    private IEnumerator Start()
    {
        yield return waitStartObj;
        startEvent.Invoke();
    }
}