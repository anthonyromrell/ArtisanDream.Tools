using UnityEngine;
using UnityEngine.Events;

public class KeyInputBehaviour : MonoBehaviour
{
    public KeyCode keyCode;
    public GameAction onKeyEvent;
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyEvent.RaiseAction();
        }
    }
}
