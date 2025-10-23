using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class AiBehaviour : MonoBehaviour
{
    public AiBrain aiBrainObj;
    private NavMeshAgent agent;
    public UnityEvent startEvent, triggerEnterEvent, triggerExitEvent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        startEvent.Invoke();
    }
    
    public void SwapAIFunction(AiBase aiBaseObj)
    {
        aiBrainObj.aiBaseObj = aiBaseObj;
    }

    private void Update()
    {
        aiBrainObj.Navigate(agent);
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