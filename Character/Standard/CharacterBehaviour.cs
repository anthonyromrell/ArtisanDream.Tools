using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    public List<CharacterPattern> characterPatterns;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        foreach (var pattern in characterPatterns)
        {
            pattern.Call(controller);
        }
    }
}