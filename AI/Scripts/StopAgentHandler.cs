using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class StopAgentHandler : MonoBehaviour
{
    [FormerlySerializedAs("HoldTime")] public FloatData holdTime;
    private NavMeshAgent agent;
    
    [FormerlySerializedAs("StopAgentAction")] public GameAction stopAgentAction;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stopAgentAction.raiseNoArgs += AgentHandler;
    }

    private void AgentHandler ()
    {
        agent.isStopped = true;
        Invoke("RestartAgent", holdTime.value);
    }

    private void RestartAgent()
    {
        agent.isStopped = false;
    }

    private void OnDestroy()
    {
        stopAgentAction.raiseNoArgs -= AgentHandler;
    }
}
