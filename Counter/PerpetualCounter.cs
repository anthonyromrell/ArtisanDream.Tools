using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PerpetualCounter : MonoBehaviour
{
    public UnityEvent onCount;
    public FloatData seconds;
    public float holdTime = 0.3f;

    private IEnumerator OnStart()
    {
        yield return new WaitForSeconds(holdTime);
        while (true)
        {
            onCount.Invoke();
            yield return new WaitForSeconds(seconds.Value);
        }
    }

    public void Restart()
    {
        StartCoroutine(OnStart());
    }
}