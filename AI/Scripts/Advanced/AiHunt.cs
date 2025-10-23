using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	[HideInInspector] public Transform destination;
	
	public void AddTransform(Transform obj)
	{
		destination = obj;
	}
	
	public override void Navigate(NavMeshAgent agent)
	{
		agent.destination = destination.position;
	}
}