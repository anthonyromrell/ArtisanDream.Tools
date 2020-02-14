using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

//Made By Anthony Romrell
public class AiBehaviour : MonoBehaviour
{   
    [FormerlySerializedAs("OnStart")] public AiBase onStart;
    [FormerlySerializedAs("OnEnter")] public AiBase onEnter;
    [FormerlySerializedAs("OnExit")] public AiBase onExit;
    [FormerlySerializedAs("ChangeBaseAction")] public GameAction changeBaseAction;
    [FormerlySerializedAs("SendTransformAction")] public GameAction sendTransformAction;
    
    [FormerlySerializedAs("Brain")] [HideInInspector]
    public AiBrain brain;
    
    [FormerlySerializedAs("Patrol")] [HideInInspector]
    public AiPatrol patrol;
    private Coroutine coroutine;
    private NavMeshAgent agent;

    private void Start()
    {
        if (changeBaseAction != null) changeBaseAction.raise += ChangeBase;
        brain = ScriptableObject.CreateInstance<AiBrain>();
        patrol = onStart as AiPatrol;
        if (patrol != null)
        {
            patrol.sendCoroutine = ScriptableObject.CreateInstance<GameAction>();
            patrol.sendCoroutine.raiseNoArgs += CallCoroutine;
        }

        agent = GetComponent<NavMeshAgent>();
        brain.Base = onStart;
        coroutine = StartCoroutine(brain.Base.Nav(agent));
    }

    private void CallCoroutine()
    {
        OnCall(coroutine);
    }

    private void OnTriggerEnter(Collider other)
    {
        brain.Base = onEnter;
        OnCall(coroutine);
    }

    private void OnTriggerExit(Collider other)
    {
        brain.Base = onExit;
        OnCall(coroutine);
    }

    private void OnCall(Coroutine c)
    {
        StopCoroutine(c);
        if (agent.isActiveAndEnabled)
        {
            coroutine = StartCoroutine(brain.Base.Nav(agent));
        }
    }

    public void ChangeBase(object ai)
    {
        var newAi = ai as AiBase;
        brain.Base = newAi;
        OnCall(coroutine);
    }
}