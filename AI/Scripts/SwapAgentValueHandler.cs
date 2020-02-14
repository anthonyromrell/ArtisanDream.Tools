using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class SwapAgentValueHandler: MonoBehaviour, IRunCoroutine
{
    [FormerlySerializedAs("SwapAction")] public GameAction swapAction;
    [FormerlySerializedAs("AiObj")] public AiBase aiObj;
    [FormerlySerializedAs("Data")] public FloatData data;
    public FloatData oldSpeed;
    [SerializeField] private Object waitObj;
    private NavMeshAgent agent;

    public IWait WaitObj
    {
        get => null;
        set {}
    }

    private void Awake()
    {
        swapAction.raiseNoArgs += Raise;
    }

    public void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        WaitObj = waitObj as IWait;
        oldSpeed = aiObj.speed;
    }

    private void Raise()
    {
        print("hit");
        aiObj.speed = data;
        agent.speed = data.value;
        StartCoroutine(RunCoroutine());
    }
    
    public IEnumerator RunCoroutine()
    {
        yield return waitObj;
        aiObj.speed = oldSpeed;
        agent.speed = data.value;
    }

    private void OnDestroy()
    {
        swapAction.raiseNoArgs -= Raise;
    }
}