using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DisableOrDestroyBehaviour : MonoBehaviour
{
    public UnityEvent startEvent;
    public UnityEvent beginDestroy;
    public UnityEvent endDestroyEvent;
    private GameObject otherObj;

    private void Start()
    {
        startEvent.Invoke();
        if (canSelfDestructOnStart)
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
        endDestroyEvent.Invoke();
        StopAllCoroutines();
    }
    
    public enum States
    {
        This,
        Other,
        Both,
        None
    }

    public bool canSelfDestructOnStart;
    public bool canTrigger;
    public bool canDestroy;
    public States state;
    public float seconds = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        otherObj = other.gameObject;
        if (canTrigger)    
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
    
    public void DestroyGameObject(GameObject obj)
    {
        Destroy(obj);
    }

    private IEnumerator OnCall ()
    {
        beginDestroy.Invoke();
        yield return new WaitForSeconds(seconds);
        
        switch (state)
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
        if (canDestroy)
        {
            Destroy(obj);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}