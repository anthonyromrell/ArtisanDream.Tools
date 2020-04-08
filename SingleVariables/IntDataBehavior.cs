using UnityEngine;
using UnityEngine.Events;

public class IntDataBehavior : MonoBehaviour
{
    public IntData dataObj;
    public UnityEvent nameTrueEvent;

    public void CompareNameToInt()
    {
        if (name == dataObj.value.ToString())
        {
            nameTrueEvent.Invoke();
        }
    }
}
