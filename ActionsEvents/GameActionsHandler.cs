using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionsHandler : MonoBehaviour
{
    public UnityEvent startEvent;

    private void Start()
    {
        startEvent.Invoke();
    }

    [Serializable]
    public struct Handlers
    {
        public GameAction action;
        public UnityEvent actionEvent;
        
        internal void Respond()
        {
            actionEvent.Invoke();
        }
    }
    
    public List<Handlers> handlerList;
    
    private void OnEnable()
    {
        foreach (var obj in handlerList)
        {
            obj.action.RaiseNoArgs += obj.Respond;
        }
    }
}
