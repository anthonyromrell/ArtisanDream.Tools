using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ColliderEvents : MonoBehaviour
{
    [FormerlySerializedAs("TriggerEnterEvent")] public UnityEvent triggerEnterEvent;
    [FormerlySerializedAs("TriggerStayEvent")] public UnityEvent triggerStayEvent;
    [FormerlySerializedAs("TriggerExitEvent")] public UnityEvent triggerExitEvent;
    [FormerlySerializedAs("CollisionEnterEvent")] public UnityEvent collisionEnterEvent;
    [FormerlySerializedAs("CollisionStayEvent")] public UnityEvent collisionStayEvent;
    [FormerlySerializedAs("CollisionExitEvent")] public UnityEvent collisionExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        triggerStayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        collisionEnterEvent.Invoke();
    }

    private void OnCollisionStay(Collision other)
    {
        collisionStayEvent.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        collisionExitEvent.Invoke();
    }
}