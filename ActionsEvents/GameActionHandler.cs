using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction action;
    public UnityEvent startEvent, respondEvent, respondLateEvent;
    public float holdTime = 0.1f;
    private WaitForSeconds waitObj;

    private void Awake()
    {
        waitObj = new WaitForSeconds(holdTime);
    }

    private void Start()
    {
        InvokeEvent(startEvent);
    }

    private void OnEnable()
    {
        if (action != null)
            action.RaiseNoArgs += Respond;
    }
    
    private void InvokeEvent(UnityEvent unityEvent)
    {
        unityEvent.Invoke();
    }

    private void OnDisable()
    {
        if (action != null)
            action.RaiseNoArgs -= Respond;
    }

    private void Respond()
    {
        InvokeEvent(respondEvent);

        if (!gameObject.activeInHierarchy) return;
        StartCoroutine(RespondLate());
    }

    private IEnumerator RespondLate()
    {
        yield return waitObj;
        InvokeEvent(respondLateEvent);
    }

    private void OnDestroy()
    {
        action.RaiseNoArgs = null;
    }
}