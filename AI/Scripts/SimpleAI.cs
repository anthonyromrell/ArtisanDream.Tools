using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAi : MonoBehaviour
{
	public Transform destination;
	private NavMeshAgent agent;
	private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();

	private IEnumerator Start ()
	{
		agent = GetComponent<NavMeshAgent>();
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