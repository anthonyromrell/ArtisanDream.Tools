using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
    public GameActionAdvanced sendTransformAction;

    public void SendTransform()
    {
        sendTransformAction.Raise(transform);
    }

    public void GetPosition(Vector3Data obj)
    {
        transform.position = obj.value;
    }
}