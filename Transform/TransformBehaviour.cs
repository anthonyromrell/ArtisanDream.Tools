using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
    public GameAction sendTransformAction;

    public void SendTransform()
    {
        sendTransformAction.raise(transform);
    }

    public void GetPosition(Vector3Data obj)
    {
        transform.position = obj.value;
    }
}