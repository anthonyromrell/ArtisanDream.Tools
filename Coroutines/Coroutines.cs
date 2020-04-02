using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coroutines : MonoBehaviour
{
    
    
    public float seconds = 1f;
    public UnityEvent startEvent, RepeatEvent, endEvent;
    private WaitForSeconds waitForSeconds;
    public bool canRun;

    public void Init ()
    {
        waitForSeconds = new WaitForSeconds(seconds);
    }

    public IEnumerator RunCoroutine()
    {
        startEvent.Invoke();
        
        while (canRun) // never set while condition to true
        {
            yield return waitForSeconds;
            RepeatEvent.Invoke();
        }
        
        endEvent.Invoke();
    }
}