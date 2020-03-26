using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	public GameAction destinationAction;
	[HideInInspector]
	public Transform destination;

	protected virtual void OnEnable()
	{
		if (destinationAction != null) destinationAction.raise += Raise;
	}

	protected void Raise(object obj)
	{
		destination = obj as Transform;
	}
	

	public override void RunAgent(NavMeshAgent agent)
	{
		agent.destination = (destination != null ? destination.position : agent.transform.position);
	}
}