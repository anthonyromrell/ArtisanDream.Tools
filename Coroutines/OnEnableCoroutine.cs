using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class OnEnableCoroutine : MonoBehaviour
{
    public UnityEvent onEnableEvent;
    public bool canRun = true;
    public float holdTime = 2f;
    private WaitForSeconds wfs;
    
    private IEnumerator Start()
    {
        wfs = new WaitForSeconds(holdTime);
        
        while (canRun)
        {
            yield return wfs;
            onEnableEvent.Invoke();
        }
    }
}