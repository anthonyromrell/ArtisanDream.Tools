using UnityEngine;
using UnityEngine.Events;


public class OnTriggerBehaviour : MonoBehaviour
{
    public UnityEvent Event;
    public UnityEvent<Collider> ColliderEvent;

    private void OnTriggerEnter(Collider other)
    {
        //Event.AddListener(null);
        //ColliderEvent.Invoke(other);
        Event.Invoke();
    }
}