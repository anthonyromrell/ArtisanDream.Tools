using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviourPlus : AgentBehaviour
{
    public Vector3DataCollection patrolPoints;
    
}