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
            onKeyEvent.raiseNoArgs();
        }
    }
}
