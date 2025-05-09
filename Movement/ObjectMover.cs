using UnityEngine;
public class ObjectMover : MonoBehaviour
{
    // Enum for movement options
    public enum MovementAxis
    {
        X,
        Y,
        Both
    }

    public MovementAxis movementAxis = MovementAxis.X;
    public float speed = 2f;
    public float distance = 3f;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Deciding on which axis to move 
        switch (movementAxis)
        {
            case MovementAxis.X:
                targetPosition.x = Mathf.PingPong(Time.time * speed, distance);
                break;
            case MovementAxis.Y:
                targetPosition.y = Mathf.PingPong(Time.time * speed, distance);
                break;
            case MovementAxis.Both:
                targetPosition.x = Mathf.PingPong(Time.time * speed, distance);
                targetPosition.y = Mathf.PingPong(Time.time * speed, distance);
                break;
        }

        // Apply change to the transform 
        transform.position = targetPosition;
    }
}