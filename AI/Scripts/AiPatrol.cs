using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    public GameAction addPointList;
    [HideInInspector]
    public List<Vector3Data> patrolPoints;
    private int i;
    
    private void OnEnable()
    {
        patrolPoints?.Clear();
        if (addPointList != null) addPointList.raise += AddPatrolPointList;
        i = 0;
    }

    private void OnDisable()
    {
        patrolPoints?.Clear();
    }

    private void AddPatrolPointList(object obj)
    {
        patrolPoints = obj as List<Vector3Data>;
    }
    
    public override void RunAgent(NavMeshAgent agent)
    {
        agent.destination = patrolPoints[i].value;
    }

    public void ChangePoint()
    {
        if (i < patrolPoints.Count - 1)
        {
            i++;
        }
        else
        {
            i = 0;
        }
    }
}