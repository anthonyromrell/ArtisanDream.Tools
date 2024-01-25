using UnityEngine;
using UnityEngine.Events;

public class MonoEventsExpandedBehaviour : MonoEventsBehaviour
{
    public GameAction disableAction, destroyAction, applicationQuitAction;
    public UnityEvent disableEvent, destroyEvent, applicationQuitEvent;
    
    private void OnDisable()
    {
        disableEvent.Invoke();
        if (disableAction != null) disableAction.RaiseNoArgs();
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
        if (destroyAction != null) destroyAction.RaiseNoArgs();
    }

    private void OnApplicationQuit()
    {
        applicationQuitEvent.Invoke();
        if (applicationQuitAction != null) applicationQuitAction.RaiseNoArgs();
    }
}