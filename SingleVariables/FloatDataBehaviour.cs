using UnityEngine;

public class FloatDataBehaviour : MonoBehaviour
{
    [SerializeField] private float dataValue;

    [SerializeField] private FloatData floatDataObj;

    public float DataValue => dataValue;

    public float FloatDataValue
    {
        get
        {
            if (floatDataObj != null)
            {
                return floatDataObj.Value;
            }
            else
            {
                Debug.LogError("FloatData object is not set.");
                return 0f;
            }
        }
    }

    public void IncrementValue(FloatData obj)
    {
        if (obj != null)
        {
            dataValue += obj.Value;
        }
        else
        {
            Debug.LogError("UpdateValue(floatData) called with null argument.");
        }
    }

    public void UpdateFloatData(float increment)
    {
        if (floatDataObj != null)
        {
            floatDataObj.UpdateValue(floatDataObj.Value + increment);
        }
        else
        {
            Debug.LogError("FloatData object is not set. Cannot update its value.");
        }
    }
}