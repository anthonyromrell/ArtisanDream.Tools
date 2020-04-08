using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    //public GameAction addPointList;
    public Vector3DataCollection patrolPoints;
    private int i;
    
    private void OnEnable()
    {
        patrolPoints.vector3Datas?.Clear();
        //if (addPointList != null) addPointList.raise += AddPatrolPointList;
        i = 0;
    }

    private void OnDisable()
    {
        if (patrolPoints != null) patrolPoints.vector3Datas?.Clear();
    }

//    private void AddPatrolPointList(object obj)
//    {
//        patrolPoints = obj as List<Vector3Data>;
//    }
    
    public override void RunAgent(NavMeshAgent agent)
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = patrolPoints.vector3Datas[i].value;
            i = (i + 1) % patrolPoints.vector3Datas.Count;
        }
    }
}