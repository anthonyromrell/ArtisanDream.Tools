using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	public GameAction GameAction;
	
	private Transform destination;

	private void OnEnable()
	{
		GameAction.Raise += Call;
	}

	private void Call(object obj)
	{
		destination = obj as Transform;
	}

	public override IEnumerator Nav(NavMeshAgent ai)
	{
		var canRun = true;
		while (canRun)
		{
			yield return new WaitForFixedUpdate();
			ai.speed = Speed.Value;
			ai.angularSpeed = AngularSpeed.Value;
			ai.destination = (destination != null ? destination.position : ai.transform.position);
		}
	}
}