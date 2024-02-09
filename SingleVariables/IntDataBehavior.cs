using UnityEngine;
using UnityEngine.Events;

public class IntDataBehavior : MonoBehaviour
{
    [SerializeField] private IntData dataObj;

    [SerializeField] private UnityEvent nameMatchedEvent;

    public string ObjectName => gameObject.name;

    public int DataObjValue
    {
        get
        {
            if (dataObj != null)
            {
                return dataObj.Value;
            }
            else
            {
                Debug.LogError("IntData object is not set.");
                return 0;
            }
        }
    }

    private void Start()
    {
        CompareAndTriggerEvents();
    }

    public void CompareAndTriggerEvents()
    {
        if (DoesObjectNameMatchValue())
        {
            InvokeNameMatchedEvent();
        }
    }

    private bool DoesObjectNameMatchValue()
    {
        return ObjectName == DataObjValue.ToString();
    }

    private void InvokeNameMatchedEvent()
    {
        if (nameMatchedEvent != null)
        {
            nameMatchedEvent.Invoke();
        }
        else
        {
            Debug.LogError("nameMatchedEvent is null. Please attach a UnityEvent.");
        }
    }
}