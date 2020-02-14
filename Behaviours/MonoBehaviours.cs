using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MonoBehaviours : MonoBehaviour
{
    [FormerlySerializedAs("AwakeEvent")] public UnityEvent awakeEvent;
    [FormerlySerializedAs("StartEvent")] public UnityEvent startEvent;
    [FormerlySerializedAs("QuitEvent")] public UnityEvent quitEvent;


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
