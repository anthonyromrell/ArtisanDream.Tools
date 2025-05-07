using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
    }
    
    public void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
}