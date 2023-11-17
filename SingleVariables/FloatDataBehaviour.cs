using UnityEngine;

public class FloatDataBehaviour : MonoBehaviour
{
    public float value;
    
    public FloatData floatDataObj;

    public void UpdateValue(FloatData obj)
    {
        value += obj.Value;
    } 
    
    public void UpdateFloatData(float number)
    {
        floatDataObj.UpdateValue(number);
    }
}