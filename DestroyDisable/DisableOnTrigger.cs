using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTrigger : MonoBehaviour
{
    public enum DisableState
    {
        This,
        Other,
        Both,
        None
    }

    public bool CanTrigger;

    public DisableState Disable;

    private void OnTriggerEnter(Collider other)
    {
        if (CanTrigger)
        {
            DisableObject (other);
        }

    }

    public void DisableOnCall(Collider other)
    {
        DisableObject (other);
    }

    private void DisableObject (Collider other)
    {
        switch (Disable)
        {
            case DisableState.This:
                gameObject.SetActive(false);
                break;
            case DisableState.Other:
                other.gameObject.SetActive(false);
                break;

            case DisableState.Both:
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
                break;
            case DisableState.None:
                
                break;
        }
    }
}