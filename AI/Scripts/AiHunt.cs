using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	public GameAction DestinationAction;

	public Transform Destination;

	protected virtual void OnEnable()
	{
		if (DestinationAction != null) DestinationAction.Raise += Raise;
	}

	protected void Raise(object obj)
	{
		Destination = obj as Transform;
	}

	public override IEnumerator Nav(NavMeshAgent ai)
	{
		while (true)
		{
			yield return new WaitForFixedUpdate();
			ai.speed = Speed.Value;
			ai.angularSpeed = AngularSpeed.Value;
			ai.destination = (Destination != null ? Destination.position : ai.transform.position);
		}
	}
}