using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviours : MonoBehaviour
{
    public UnityEvent AwakeEvent, StartEvent, QuitEvent;
    
    
    private void Awake()
    {
        AwakeEvent.Invoke();
    }

    private void Start()
    {
        
    }

    private void OnApplicationQuit()
    {
        QuitEvent.Invoke();
    }
}
