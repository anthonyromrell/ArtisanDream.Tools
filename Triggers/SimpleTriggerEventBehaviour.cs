using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent awakeEvent, triggerEvent;
    
    private void Awake()
    {
        awakeEvent.Invoke();
        GetComponent<BoxCollider>().isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
    }
}