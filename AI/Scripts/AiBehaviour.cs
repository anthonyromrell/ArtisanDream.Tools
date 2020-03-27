using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AiBehaviour : MonoBehaviour
{
    public AiBrain aiBrainObj;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        aiBrainObj.Navigate(agent);
    }
}