using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AiBehaviour : MonoBehaviour
{
    public AiBrain aiBrainObj;
    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    public bool CanRun { get; set; } = true;
    
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
}