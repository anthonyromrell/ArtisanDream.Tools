using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Hunt2D", menuName = "Ai/Function/Hunt2D")]
public class AiHunt2D : AiHunt
{
    public override void RunAgent(NavMeshAgent agent)
    {
        agent.transform.LookAt(agent.steeringTarget);
        base.RunAgent(agent);
    }
}