using UnityEngine;
using UnityEngine.Events;

public class KeyInputBehaviour : MonoBehaviour
{
    public KeyCode keyCode;
    public UnityEvent onKeyEvent;
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyEvent.Invoke();
        }
    }
}
