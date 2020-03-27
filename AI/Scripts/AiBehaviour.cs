using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AiBehaviour : MonoBehaviour
{
    public AiBrain aiBrainObj;
    public bool canRun = true;
    private NavMeshAgent agent;
    private WaitForFixedUpdate waitFor = new WaitForFixedUpdate();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator Start()
    {
        canRun = true;
        while (canRun)
        {
            aiBrainObj.Navigate(agent);
            yield return waitFor;
        }
    }
}