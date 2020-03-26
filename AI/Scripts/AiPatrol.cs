using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    [HideInInspector] public GameAction sendCoroutine;
    public GameAction addPointList;
    public FloatData distance;
    public List<Vector3Data> patrolPoints;

    private int i;
    
    private void OnEnable()
    {
        patrolPoints?.Clear();
        if (addPointList != null) addPointList.raise += AddPatrolPointList;
        i = 0;
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