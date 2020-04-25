using System.Collections;
using UnityEngine;

public class TransformDirectionChanger : MonoBehaviour
{
    private const int RotationAmount = 180;
    public Transform transformObj;
    private WaitForSeconds waitObj;
    public float holdTime = 0.1f;

    private void Start()
    {
        waitObj = new WaitForSeconds(holdTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return waitObj;
        transformObj.Rotate(0, RotationAmount, 0); 
    }
}