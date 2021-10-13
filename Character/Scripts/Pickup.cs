using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickup : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody rigidbodyObj;
    private bool canPickup;

    //Why is causing Player's Health? When I press K. It sets up and why is that?
    void Start()
    {
        rigidbodyObj = GetComponent<Rigidbody>();
        rigidbodyObj.useGravity = false;
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.K))
        {
            rigidbodyObj.isKinematic = true;
            var transformObj = transform;
            transformObj.position = playerTransform.position;
            transformObj.parent = playerTransform;
            canPickup = false;
        }
        
        if (!canPickup && Input.GetKeyUp(KeyCode.K))
        {
            rigidbodyObj.isKinematic = true;
            var transformObj = transform;
            transformObj.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTransform = other.transform;
        canPickup = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}

