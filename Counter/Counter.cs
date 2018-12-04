using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public UnityEvent OnCount;

    public float Seconds = 2.0f;
    public int Numbers = 30;

    IEnumerator Start()
    {
        while (Numbers > 0)
        {
            OnCount.Invoke();
            yield return new WaitForSeconds(Seconds);
            Numbers--;
        }
    }
}