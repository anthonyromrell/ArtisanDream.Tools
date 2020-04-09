using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class AiBehaviour : MonoBehaviour
{
    public AiBrain aiBrainObj;
    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    public bool CanRun { get; set; } = true;
    public UnityEvent triggerEnterEvent, triggerExitEvent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Stop(bool stopped)
    {
        agent.isStopped = stopped;
    }
    
    public void Restart()
    {
        StartCoroutine(Start());
    }
    private IEnumerator Start()
    {
        CanRun = true;
        while (CanRun)
        {
            aiBrainObj.Navigate(agent);
            yield return waitObj;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}