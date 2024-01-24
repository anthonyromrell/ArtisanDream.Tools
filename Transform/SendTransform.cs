using UnityEngine;

public class SendTransform : MonoBehaviour
{
    public GameAction sendTransformAction;

    private void Start()
    {
        sendTransformAction.Raise?.Invoke(transform);
    }
}