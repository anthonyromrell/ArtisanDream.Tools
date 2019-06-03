using UnityEngine;
using UnityEngine.Events;

public class ColliderEvents : MonoBehaviour
{
    public UnityEvent TriggerEnterEvent, TriggerStayEvent, TriggerExitEvent;
    public UnityEvent CollisionEnterEvent, CollisionStayEvent, CollisionExitEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExitEvent.Invoke();
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        CollisionEnterEvent.Invoke();
    }

    private void OnCollisionStay(Collision other)
    {
        CollisionStayEvent.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        CollisionExitEvent.Invoke();
    }
}