using UnityEngine;
using UnityEngine.Events;

public class DisableBehaviour : MonoBehaviour
{
    public UnityEvent Event;

    private void OnDisable()
    {
        Event.Invoke();
    }
}