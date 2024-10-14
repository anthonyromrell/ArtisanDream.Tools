using System;
using UnityEngine;
public class TriggerGameActionBehaviour : MonoBehaviour
{
    public GameAction action;
    
    public void OnTriggerEnter(Collider other)
    {
        action.RaiseNoArgs();
    }
}