using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class SimpleAi : MonoBehaviour
{
	[FormerlySerializedAs("Destination")] public Transform destination;
	private NavMeshAgent agent;

	private IEnumerator Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		while (true)
		{
			yield return new WaitForFixedUpdate();
			agent.destination = destination.position;
		}
	}

	public void Restart()
	{
		StartCoroutine(Start());
	}
}
