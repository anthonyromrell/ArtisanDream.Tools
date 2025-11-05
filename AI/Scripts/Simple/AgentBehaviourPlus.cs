using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviourPlus : AgentBehaviour
{
    public List<Transform> patrolPointTransforms;
    private List<Vector3> patrolPoints;
    
    private int currentPatrolIndex = 0;
    private bool isPatrolling = true;
    
    // Covert Transform list to Vector3 list for patrol points
    protected override void Start()
    {
        base.Start();
        patrolPoints = new List<Vector3>();
        foreach (var point in patrolPointTransforms)
        {
            patrolPoints.Add(point.position);
        }
        if (patrolPoints.Count > 0)
        {
            agent.destination = patrolPoints[currentPatrolIndex];
        }
    }
    
    protected override void Update()
    {
        if (isPatrolling)
        {
            if (agent.pathPending || !(agent.remainingDistance < 0.5f)) return;
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
            agent.destination = patrolPoints[currentPatrolIndex];
        }
        else
        {
            base.Update();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPatrolling = false;
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isPatrolling = true;
        agent.destination = patrolPoints[currentPatrolIndex];
    }
}