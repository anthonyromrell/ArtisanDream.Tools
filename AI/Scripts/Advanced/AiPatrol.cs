using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    public Vector3DataCollection patrolPoints;
    private int i;

    protected virtual void OnEnable()
    {
        patrolPoints.vector3DataList?.Clear();
        i = 0;
    }

    private void OnDisable()
    {
        if (patrolPoints != null) patrolPoints.vector3DataList?.Clear();
    }

    public override void RunAgent(NavMeshAgent agent)
    {
        if (agent.pathPending || !(agent.remainingDistance < 0.5f)) return;
        agent.destination = patrolPoints.vector3DataList[i].value;
        i = (i + 1) % patrolPoints.vector3DataList.Count;
    }
}