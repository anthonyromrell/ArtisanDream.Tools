using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Simple FloatData")]
public class SimpleFloatData : ScriptableObject
{
    public float value;
    
    public void UpdateValue(float amount)
    {
        value += amount;
    }
    
    //SetData ()
    public void SetValue(float amount)
    {
        value = amount;
    }
}
