using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    public CharacterPattern characterPatterns;
    private WaitForFixedUpdate waitObj;

    public bool CanRun { get; set; } = true;

    void Awake()
    {
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
}