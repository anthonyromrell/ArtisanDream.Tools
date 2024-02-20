using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCoroutineBehaviour : MonoBehaviour
{
    public float Seconds = 1;
    private WaitForSeconds wait;
    public UnityEvent Event;

    private void Awake()
    {
        wait = new WaitForSeconds(Seconds);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return wait;
            Event.Invoke();
        }
    }
}
