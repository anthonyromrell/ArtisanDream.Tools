using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
    public GameAction transformAction;
   
    public void SendTransform()
    {
        transformAction.raise(transform);
    }
}