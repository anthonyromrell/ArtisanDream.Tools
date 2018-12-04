using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PerpetualCounter : MonoBehaviour
{
    public UnityEvent OnCount;
    public FloatData Seconds;
    public float HoldTime = 0.3f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(HoldTime);
        while (true)
        {
            OnCount.Invoke();
            yield return new WaitForSeconds(Seconds.Value);
        }
    }

    public void Restart()
    {
        StartCoroutine(Start());
    }
}