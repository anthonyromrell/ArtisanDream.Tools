using UnityEngine;

public class ShrinkOnCollision : MonoBehaviour
{
    public float shrinkFactor = 0.9f;

    void OnCollisionEnter(Collision collision)
    {
        // Scale the object down when it collides with another object
        transform.localScale *= shrinkFactor;
    }
}