using System.Collections;
using UnityEngine;

public class Vector3DataSystemBehaviour : MonoBehaviour
{
    public Vector3DataSystem vector3DataSystem;
    public float snapSpeed = 2f;
    public Vector3Data vector3DataObj;
    private bool canRun = true;
    private WaitForFixedUpdate waitForFixedUpdateObj;

    private void Start()
    {
        waitForFixedUpdateObj = new WaitForFixedUpdate();
    }

    public void SnapToVData()
    { 
        StartCoroutine(MoveToVData());
    }
    
    private IEnumerator MoveToVData()
    {
        canRun = true;
        while (canRun)
        {
            yield return waitForFixedUpdateObj;
            transform.position = Vector3.Lerp(transform.position, vector3DataObj.value, snapSpeed);
            if (transform.position.normalized == vector3DataObj.value.normalized)
            {
                canRun = false;
            }
        }			
    }

    private void OnDestroy()
    {
        vector3DataSystem.AddBack(vector3DataObj);
    }
}