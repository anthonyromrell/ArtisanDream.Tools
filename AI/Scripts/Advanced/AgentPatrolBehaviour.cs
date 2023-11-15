using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentPatrolBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public float remainingDistanceNum = 0.5f;
    public List<Transform> patrolPointList;
    private int i;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (agent.pathPending || !(agent.remainingDistance < remainingDistanceNum)) return;
        agent.destination = patrolPointList[i].position;
        i = (i + 1) % patrolPointList.Count;
    }
}
