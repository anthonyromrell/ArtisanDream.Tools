using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
	public Transform Destination;
	private NavMeshAgent agent;

	private IEnumerator Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		while (true)
		{
			yield return new WaitForFixedUpdate();
			agent.destination = Destination.position;
		}
	}

	public void Restart()
	{
		StartCoroutine(Start());
	}
}
