using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    public CharacterPattern characterPatterns;
    private WaitForFixedUpdate waitObj;
    public UnityEvent awakeEvent, triggerEnterEvent, triggerExitEvent;
    public bool CanRun { get; set; } = true;

    private void Awake()
    {
        awakeEvent.Invoke();
        waitObj = new WaitForFixedUpdate();
        controller = GetComponent<CharacterController>();
    }

    public void SwapPattern(CharacterPattern pattern)
    {
        characterPatterns = pattern;
    }

    public void Restart()
    {
        StartCoroutine(Start());
    }
    
    private IEnumerator Start()
    {
        CanRun = true;
        while (CanRun)
        {
            yield return waitObj;
            characterPatterns.Call(controller);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}