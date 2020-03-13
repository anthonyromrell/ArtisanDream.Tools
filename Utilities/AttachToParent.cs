using UnityEngine;
using UnityEngine.Events;

public class AttachToParent : MonoBehaviour
{
    public NameId parentId;
    private void OnTriggerEnter(Collider other)
    {
        var nameIdObj = other.GetComponent<IdBehaviour>().nameIdObj;
        
        if (nameIdObj != null && parentId == nameIdObj)
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
}
