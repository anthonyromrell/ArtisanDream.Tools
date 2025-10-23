using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol2D")]
public class AIPattrol2d : AiPatrol
{
    public override void Navigate(NavMeshAgent agent)
    {
        agent.transform.LookAt(agent.steeringTarget);
        base.Navigate(agent);
    }
}
