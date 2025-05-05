using UnityEngine;
using UnityEngine.Events;

public class BoolBehaviour : MonoBehaviour
{
    public UnityEvent trueEvent, falseEvent;
    public SimpleBoolData boolData;
    
    public void CheckBool()
    {
        if (boolData.value)
        {
            trueEvent.Invoke();
        }
        else
        {
            falseEvent.Invoke();
        }
    }
}
