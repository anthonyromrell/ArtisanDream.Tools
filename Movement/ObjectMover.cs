using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    void Update()
    {
        // Move the object back and forth along the X axis
        float x = Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}