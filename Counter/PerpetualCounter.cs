using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PerpetualCounter : MonoBehaviour
{
    public UnityEvent onCount;
    public FloatData seconds;
    public float holdTime = 0.3f;
    private readonly WaitForFixedUpdate waitObj;

    private IEnumerator OnStart()
    {
        yield return waitObj;
        while (true)
        {
            onCount.Invoke();
            yield return waitObj;
        }
    }

    public void Restart()
    {
        StartCoroutine(OnStart());
    }
}