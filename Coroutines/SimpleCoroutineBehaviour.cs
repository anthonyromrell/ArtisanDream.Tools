using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SimpleCoroutineBehaviour : MonoBehaviour
{
    public float seconds = 1;
    private WaitForSeconds _waitForSeconds;
    public UnityEvent @event;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(seconds);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return _waitForSeconds;
            @event.Invoke();
        }
    }
}
