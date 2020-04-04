using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehaviour : MonoBehaviour
{
    public float seconds = 1f;
    public UnityEvent startEvent, RepeatEvent, endEvent;
    private WaitForSeconds waitForSeconds;
    public bool canRun;
    
    public void Awake ()
    {
        waitForSeconds = new WaitForSeconds(seconds);
    }

    public void CallStartCoroutine()
    {
        StartCoroutine(RunCoroutine());
    }

    private IEnumerator RunCoroutine()
    {
        canRun = true;
        startEvent.Invoke();
        while (canRun) 
        {
            yield return waitForSeconds;
            RepeatEvent.Invoke();
        }
        
        endEvent.Invoke();
    }
}