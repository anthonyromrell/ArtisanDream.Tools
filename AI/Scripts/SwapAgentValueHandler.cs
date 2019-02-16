using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SwapAgentValueHandler: MonoBehaviour, IRunCoroutine
{
    public GameAction SwapAction;
    public AiBase AiObj;
    public FloatData Data;
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
        SwapAction.RaiseNoArgs += Raise;
    }

    public void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        WaitObj = waitObj as IWait;
        oldSpeed = AiObj.Speed;
    }

    private void Raise()
    {
        print("hit");
        AiObj.Speed = Data;
        agent.speed = Data.Value;
        StartCoroutine(RunCoroutine());
    }
    
    public IEnumerator RunCoroutine()
    {
        yield return waitObj;
        AiObj.Speed = oldSpeed;
        agent.speed = Data.Value;
    }

    private void OnDestroy()
    {
        SwapAction.RaiseNoArgs -= Raise;
    }
}