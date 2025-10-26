using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class AiBehaviour : MonoBehaviour
{
    public AiStats aiStatsObj;
    private AiBase aiBaseObj;
    private NavMeshAgent agent;
    public UnityEvent startEvent, triggerEnterEvent, triggerExitEvent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        startEvent.Invoke();
        
        if (aiStatsObj == null) return;
        agent.speed = aiStatsObj.speed;
        agent.acceleration = aiStatsObj.acceleration;
        agent.angularSpeed = aiStatsObj.angularSpeed;
        agent.stoppingDistance = aiStatsObj.stoppingDistance;
    }

    public void ChangeBase(AiBase obj)
    {
        aiBaseObj = obj;
    }
    private void Update()
    {
        aiBaseObj.Navigate(agent);
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}