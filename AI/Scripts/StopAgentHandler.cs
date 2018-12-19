using UnityEngine;
using UnityEngine.AI;

public class StopAgentHandler : MonoBehaviour
{
    public FloatData HoldTime;
    private NavMeshAgent agent;
    
    public GameAction StopAgentAction;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StopAgentAction.RaiseNoArgs += AgentHandler;
    }

    private void AgentHandler ()
    {
        agent.isStopped = true;
        Invoke("RestartAgent", HoldTime.Value);
    }

    private void RestartAgent()
    {
        agent.isStopped = false;
    }

    private void OnDestroy()
    {
        StopAgentAction.RaiseNoArgs -= AgentHandler;
    }
}
