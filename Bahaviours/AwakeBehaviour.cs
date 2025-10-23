using UnityEngine;
using UnityEngine.Events;

public class AwakeBehaviour : MonoBehaviour
{
    public UnityEvent awakeEvent;
    
    private void Awake()
    {
        awakeEvent.Invoke();
    }
}
