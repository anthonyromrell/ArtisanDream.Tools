using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehaviours : MonoBehaviour
{
    public UnityEvent awakeEvent, startEvent, runEvent;

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
}