using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PatrolPointControl : MonoBehaviour
{
	[FormerlySerializedAs("AiPatrol")] public AiPatrol aiPatrol;

	void OnEnable ()
	{
		aiPatrol.patrolPoints = new List<Vector3Data>(GetComponentsInChildren<Vector3Data>());
	}
}