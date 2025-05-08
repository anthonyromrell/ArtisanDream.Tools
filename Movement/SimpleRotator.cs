using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the object around the Y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}