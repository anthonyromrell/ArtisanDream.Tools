using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviourPlus : MonoBehaviour
{
    [SerializeField] // Make this field private and serialized to apply encapsulation.
    private Transform destination;

    private NavMeshAgent agent;
    private Coroutine routine;
    private readonly WaitForFixedUpdate waitObj;

    private void Awake()
    {
        EnsureDestinationNotNull();
        RetrieveNavMeshAgentComponent();
    }

    private void Start()
    {
        EnsureDestinationNotNull();
        StartUpdatingAgentDestination();
    }

    private void RetrieveNavMeshAgentComponent()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void StartUpdatingAgentDestination()
    {
        routine = StartCoroutine(UpdateDestinationCoroutine()); // Store the Coroutine.
    }

    private void EnsureDestinationNotNull()
    {
        if (destination == null)
        {
            Debug.LogError("Destination is not assigned in AgentBehaviourPlus script on " + gameObject.name);
        }
    }

    private IEnumerator UpdateDestinationCoroutine()
    {
        while (true)
        {
            yield return waitObj;
            agent.destination = destination.position;
        }
    }

    public void RestartAgent()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = StartCoroutine(UpdateDestinationCoroutine()); // Restart the Coroutine.
    }

    public void StopAgent()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
    }
}