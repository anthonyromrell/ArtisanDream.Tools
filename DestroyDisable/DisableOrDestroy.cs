using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DisableOrDestroy : MonoBehaviour
{
    
    public UnityEvent StartEvent, BeginDestroy, EndDestroyEvent;
    private GameObject otherObj;

    private void Start()
    {
        StartEvent.Invoke();
        if (CanSelfDestructOnStart)
        {
            StartCoroutine(OnCall());
        }
    }

    private void OnDisable()
    {
        EndAll();
    }
    
    private void OnDestroy()
    {
        EndAll();
    }

    private void EndAll()
    {
        EndDestroyEvent.Invoke();
        StopAllCoroutines();
    }
    
    public enum States
    {
        This,
        Other,
        Both,
        None
    }

    public bool CanSelfDestructOnStart;
    public bool CanTrigger;
    public bool CanDestroy;
    public States State;
    public float Seconds = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        otherObj = other.gameObject;
        if (CanTrigger)    
        {
            StartCoroutine(OnCall());
        }
    }

    public void Call()
    {
        StartCoroutine(OnCall());
    }
    
    public void DestroyComponent(Object obj)
    {
        Destroy(obj);
    }

    private IEnumerator OnCall ()
    {
        BeginDestroy.Invoke();
        yield return new WaitForSeconds(Seconds);
        
        switch (State)
        {
            case States.This:
                EndCall(gameObject);
                break;
            case States.Other:
                EndCall(otherObj);
                break;

            case States.Both:
                EndCall(gameObject);
                EndCall(otherObj);
                break;
            case States.None:
                
                break;
        }
    }

    private void EndCall(GameObject obj)
    {
        if (CanDestroy)
        {
            Destroy(obj);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}