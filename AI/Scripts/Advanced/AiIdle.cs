using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Idle", menuName = "Ai/Function/Idle")]
public class AiIdle : AiBase {
	

	public override void RunAgent(NavMeshAgent agent)
	{
		agent.destination = agent.transform.position;
	}
}
