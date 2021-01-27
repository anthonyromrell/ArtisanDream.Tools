using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehaviours : MonoBehaviour
{
    public UnityEvent awakeEvent, startEvent;

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private void Start()
    {
        startEvent.Invoke();
    }
}