using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRigidbodyForce : MonoBehaviour
{
    public float forceValue = 30f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward *-1f * forceValue);   
    }
}