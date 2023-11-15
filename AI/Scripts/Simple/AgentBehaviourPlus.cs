using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviourPlus : MonoBehaviour
{
	public Transform destination;
	private NavMeshAgent agent;
	private readonly WaitForFixedUpdate waitObj = new WaitForFixedUpdate();

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private IEnumerator Start ()
	{
		while (true)
		{
			yield return waitObj;
			agent.destination = destination.position;
		}
	}

	public void Restart()
	{
		StartCoroutine(Start());
	}
}