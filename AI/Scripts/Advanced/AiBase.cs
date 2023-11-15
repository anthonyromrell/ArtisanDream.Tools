using UnityEngine;
using UnityEngine.AI;

public abstract class AiBase : ScriptableObject
{
	public float speed = 3.5f;
	public float angularSpeed = 120f;
	
	public virtual void RunAgent(NavMeshAgent agent)
	{
		agent.speed = speed;
		agent.angularSpeed = angularSpeed;
	}
}