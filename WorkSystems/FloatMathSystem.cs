using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Systems/Float Math")]
public class FloatMathSystem : WorkSystem
{
    public FloatData dataObj;
    private FloatData fromNameId;
    
    public override void Work()
    {
        fromNameId = NameIdObj as FloatData;
        workEvent.Invoke();
    }
    
    public void UpdateValue ()
    {
        dataObj.UpdateValue(fromNameId.value);
    }
    
    public void ChangeValue ()
    {
        dataObj.value = fromNameId.value;
    }
    
    public void IncrementValue ()
    {
        dataObj.IncrementValue();
    }
}