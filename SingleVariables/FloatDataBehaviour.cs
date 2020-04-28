using UnityEngine;

public class FloatDataBehaviour : MonoBehaviour
{
    public FloatData floatDataObj;

    public void UpdateFloatData(float number)
    {
        floatDataObj.UpdateValue(number);
    }
}
