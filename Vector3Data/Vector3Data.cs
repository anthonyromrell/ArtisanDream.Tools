using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/Vector3Data")]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
       
    public void UpdateValue(Transform obj)
    {
        value = obj.position;
    }

    public void UpdateTransform(Transform obj)
    {
        obj.localPosition = value;  
    }

    public void UpdateXValue(float num)
    {
        value.x += num;
    }
    
    public void UpdateYValue(float num)
    {
        value.y += num;
    }
    
    public void UpdateZValue(float num)
    {
        value.z += num;
    }
    
    public void SetXValue(float num)
    {
        value.x = num;
    }
    
    public void SetYValue(float num)
    {
        value.y = num;
    }
    
    public void SetZValue(float num)
    {
        value.z = num;
    }
}