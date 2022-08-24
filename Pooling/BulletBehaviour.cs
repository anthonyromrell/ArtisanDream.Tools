using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rbObj;
    private WaitForSeconds wfsObj;
    public GameAction sendToPool;
    public float force = 10, holdTime = 2f;
    public Transform startPoint;
    private void Awake()
    {
        wfsObj = new WaitForSeconds(holdTime);
        rbObj = GetComponent<Rigidbody>();
        rbObj.useGravity = false;
        rbObj.Sleep();
        AddToPool(gameObject);
        gameObject.SetActive(false);
    }

    private IEnumerator Start()
    {
        rbObj.WakeUp();
        rbObj.velocity = Vector3.right*force;
        yield return wfsObj;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        rbObj.Sleep();
    }

    private void OnEnable()
    {
        transform.position = startPoint.position;
        StartCoroutine(Start());
    }

    public void AddToPool(GameObject obj)
    {
        sendToPool.raise(obj);
    }
}