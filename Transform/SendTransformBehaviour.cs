using UnityEngine;
using UnityEngine.Events;

public class SendTransformBehaviour : MonoBehaviour
{
    public UnityEvent awakeEvent;
    
    private void Awake()
    {
       awakeEvent.Invoke();
    }
    
    public void SendTransform(AiPatrol obj)
    {
        obj.AddTransform(transform);
    }
    
    public void SendTransform(AiHunt obj)
    {
        obj.AddTransform(transform);
    }
}