using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviours : MonoBehaviour
{
    public UnityEvent awakeEvent;
    public UnityEvent startEvent;
    public UnityEvent quitEvent;


    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private void Start()
    {
        
    }

    private void OnApplicationQuit()
    {
        quitEvent.Invoke();
    }
}
