using System;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AiBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public AiBrain aiBrainObj;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        aiBrainObj.Navigate(agent);
    }
}