using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    public UnityEvent NextPatrol, EndPatrol;
    [HideInInspector] public GameAction SendCoroutine;
    public GameAction AddPointList;
    public FloatData Distance, HoldTime;

    public List<Vector3Data> PatrolPoints { private get; set; }

    private int i;
    
    private void OnEnable()
    {
        PatrolPoints.Clear();
        if (AddPointList != null) AddPointList.Raise += AddPatrolPointList;
        i = 0;
    }

    private void AddPatrolPointList(object obj)
    {
        PatrolPoints = obj as List<Vector3Data>;
    }

    public void RestartPatrol()
    {
        SendCoroutine.RaiseNoArgs();
    }

    public override IEnumerator Nav(NavMeshAgent ai)
    {
        yield return new WaitForSeconds(HoldTime.Value);
        ai.SetDestination(PatrolPoints[i].Value);
        var canRun = true;
        while (canRun)
        {
            yield return new WaitForFixedUpdate();
            
            if ((!(ai.remainingDistance <= Distance.Value))) continue;
            
            if (i < PatrolPoints.Count - 1)
            {
                i++;
                canRun = false;
                NextPatrol.Invoke();
            }
            else
            {
                i = 0;
                canRun = false;
                EndPatrol.Invoke();
            }
        }
    }
}