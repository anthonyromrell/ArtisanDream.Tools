using System.Collections.Generic;
using UnityEngine;

public class KeyInputBehaviour : MonoBehaviour
{
    public KeyCode keyCode;
    public List<KeyCode> keyCodes;
    public GameAction onKeyEvent;
    private bool isOnKeyEventNotNull;

    private void Start()
    {
        isOnKeyEventNotNull = onKeyEvent != null;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(keyCode)) return;
        if (isOnKeyEventNotNull) onKeyEvent.RaiseNoArgs();
        Debug.Log(keyCode);
    }
}
