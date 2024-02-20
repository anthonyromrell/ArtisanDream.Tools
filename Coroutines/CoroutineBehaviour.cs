using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehaviour : MonoBehaviour
{
    // Assuming you have a UnityEvent defined somewhere in your script
    public UnityEvent repeatUntilFalseEvent;

    // Reference to the WaitForFixedUpdate object
    private readonly WaitForFixedUpdate _waitForFixedUpdateObj = new WaitForFixedUpdate();

    // Control flag for coroutine
    private bool isRunning = false;

    // Coroutine
    private IEnumerator RepeatFixedUpdate()
    {
        while (isRunning)
        {
            yield return _waitForFixedUpdateObj;
            repeatUntilFalseEvent.Invoke();
        }
    }

    // Method to start the Coroutine
    public void StartRepeatedUpdate()
    {
        if (isRunning) return;
        isRunning = true;
        StartCoroutine(nameof(RepeatFixedUpdate));
    }

    // Method to stop the Coroutine
    public void StopRepeatedUpdate()
    {
        isRunning = false;
    }

    // Method to toggle the Coroutine
    public void ToggleRepeatedUpdate()
    {
        isRunning = !isRunning;
        if (isRunning)
            StartCoroutine(nameof(RepeatFixedUpdate));
    }
}