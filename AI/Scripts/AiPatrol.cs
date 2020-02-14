using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Patrol", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
    [FormerlySerializedAs("NextPatrol")] public UnityEvent nextPatrol;
    [FormerlySerializedAs("EndPatrol")] public UnityEvent endPatrol;
    [FormerlySerializedAs("SendCoroutine")] [HideInInspector] public GameAction sendCoroutine;
    [FormerlySerializedAs("AddPointList")] public GameAction addPointList;
    [FormerlySerializedAs("Distance")] public FloatData distance;
    [FormerlySerializedAs("HoldTime")] public FloatData holdTime;

    public List<Vector3Data> PatrolPoints { private get; set; }

    private int i;
    
    private void OnEnable()
    {
        PatrolPoints?.Clear();
        if (addPointList != null) addPointList.raise += AddPatrolPointList;
        i = 0;
    }

    private void AddPatrolPointList(object obj)
    {
        PatrolPoints = obj as List<Vector3Data>;
    }

    public void RestartPatrol()
    {
        sendCoroutine.raiseNoArgs();
    }

    public override IEnumerator Nav(NavMeshAgent ai)
    {
        yield return new WaitForSeconds(holdTime.value);
        ai.SetDestination(PatrolPoints[i].value);
        var canRun = true;
        while (canRun)
        {
            yield return new WaitForFixedUpdate();
            
            if ((!(ai.remainingDistance <= distance.value))) continue;
            
            if (i < PatrolPoints.Count - 1)
            {
                i++;
                Debug.Log(this+" "+i);
                canRun = false;
                nextPatrol.Invoke();
            }
            else
            {
                i = 0;
                Debug.Log("end");
                canRun = false;
                endPatrol.Invoke();
            }
        }
    }
}