using UnityEngine;
using UnityEngine.Events;

public class IntDataBehavior : MonoBehaviour
{
    public IntData dataObj;
    public UnityEvent nameTrueEvent;

    public void CompareNameToInt()
    {
        if (name == dataObj.Value.ToString())
        {
            nameTrueEvent.Invoke();
        }
    }
}
