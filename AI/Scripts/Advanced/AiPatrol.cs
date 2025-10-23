using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    [HideInInspector] public List<Vector3> patrolPoints;
    private int i;
    protected virtual void OnEnable()
    {
        i = 0;
    }
    
    public void AddTransform(Transform obj)
    {
        patrolPoints.Add(obj.position);
    }

    private void OnDisable()
    {
        patrolPoints?.Clear();
    }

    public override void Navigate(NavMeshAgent agent)
    {
        if (patrolPoints.Count == 0) return;
        if (agent.pathPending || !(agent.remainingDistance < 0.5f)) return;
        agent.destination = patrolPoints[i];
        i = (i + 1) % patrolPoints.Count;
    }
}