using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyRigidbodyForce : MonoBehaviour
{
    public float forceValue = 30f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * forceValue);   
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     Destroy(collision.gameObject);
    //     Destroy(gameObject);
    // }
}