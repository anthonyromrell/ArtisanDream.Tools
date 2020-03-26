using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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