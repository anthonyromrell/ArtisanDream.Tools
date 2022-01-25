using System.Collections;
using UnityEngine;

public class AutoPoolingBehaviour : MonoBehaviour
{
    //public static UnityAction<Vector3> ActivateEnemyEvent; //invokes the delegate
    private bool canSpawn;
    public float randomSpawningTime = 10; 
    public PoolControl poolControlObj;

    private void OnTriggerEnter(Collider other)
    {
        canSpawn = true;
        StartCoroutine(ActivatePooling()); 
    }

    private void OnTriggerExit(Collider other)
    {
        canSpawn = false;
    }

    private IEnumerator ActivatePooling()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(0, randomSpawningTime));
            poolControlObj.ActivateObj(transform.position);
        }
    }
}