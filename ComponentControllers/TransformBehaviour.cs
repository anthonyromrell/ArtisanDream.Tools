using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
    public GameAction sendTransformAction;

    public void SentTransform()
    {
        sendTransformAction.raise(transform);
    }
}