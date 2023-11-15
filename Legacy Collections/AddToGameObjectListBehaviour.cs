using UnityEngine;

public class AddToGameObjectListBehaviour : MonoBehaviour
{
    public GameAction sendToListAction;

    private void Start()
    {
        sendToListAction.raise(gameObject);
    }
}