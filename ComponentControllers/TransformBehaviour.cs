using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
<<<<<<< HEAD
    public GameAction transformAction;
   
    public void SendTransform()
    {
        transformAction.raise(transform);
=======
    public GameAction sendTransformAction;

    public void SentTransform()
    {
        sendTransformAction.raise(transform);
>>>>>>> master
    }
}