using UnityEngine;
public class Vector3TransformBehaviour : MonoBehaviour
{
    public Vector3Data vector3Data;
    
    public void SetPosition()
    {
        transform.position = vector3Data.value;
    }
    
    public void GetPosition()
    {
        vector3Data.value = transform.position;
    }
}
