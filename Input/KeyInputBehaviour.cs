using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInputBehaviour : MonoBehaviour
{
    public KeyCode keyCode;
    public List<KeyCode> keyCodes;
    public GameAction onKeyEvent;
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyEvent.Raise();
        }
    }
    
    //fixed Update move a rigidbody with a force of 5 in y axis when the key is pressed 
    // void FixedUpdate()
    
}
