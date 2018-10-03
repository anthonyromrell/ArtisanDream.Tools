using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{

	private NavMeshAgent agent;

	public Transform destination;
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void OnTriggerStay ()
	{
		agent.destination = destination.position;
	}
}
