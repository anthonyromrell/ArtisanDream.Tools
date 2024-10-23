using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    
    //set trigger to isTrigger
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
    }
}