using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehaviours : MonoBehaviour
{
    public UnityEvent awakeEvent, startEvent, runEvent, disableEvent;

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private void Start()
    {
        startEvent.Invoke();
    }

    public void Run()
    {
        runEvent.Invoke();
    }

    private void OnDisable()
    {
        disableEvent.Invoke();
    }
}