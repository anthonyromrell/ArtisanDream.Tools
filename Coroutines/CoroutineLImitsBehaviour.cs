using System.Collections;
using UnityEngine;

public class CoroutineLimitsBehaviour : MonoBehaviour
{
    public float limitNum, rateNum;
    private Vector3 positionVector3 = new Vector3();
    
    private WaitForFixedUpdate wffuObj;
    private void Start()
    {
        wffuObj = new WaitForFixedUpdate();
        positionVector3 = transform.position;
        RunCoroutine();
    }

    public void RunCoroutine()
    {
        StartCoroutine(CoroutineWithLimit());
    }
    
    private IEnumerator CoroutineWithLimit()
    {
        while (transform.position.x < limitNum)
        {
            positionVector3.x += rateNum;
            transform.Translate(positionVector3);
            yield return wffuObj;
        }
    }
}