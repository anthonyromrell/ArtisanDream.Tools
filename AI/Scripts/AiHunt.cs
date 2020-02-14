using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	[FormerlySerializedAs("DestinationAction")] public GameAction destinationAction;

	[FormerlySerializedAs("Destination")] public Transform destination;

	protected virtual void OnEnable()
	{
		if (destinationAction != null) destinationAction.raise += Raise;
	}

	protected void Raise(object obj)
	{
		destination = obj as Transform;
	}

	public override IEnumerator Nav(NavMeshAgent ai)
	{
		while (true)
		{
			yield return new WaitForFixedUpdate();
			ai.speed = speed.value;
			ai.angularSpeed = angularSpeed.value;
			ai.destination = (destination != null ? destination.position : ai.transform.position);
		}
	}
}