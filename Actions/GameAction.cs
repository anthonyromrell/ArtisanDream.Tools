using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> raise;
    public UnityAction<Coroutine> raiseCoroutine;
    public UnityAction raiseNoArgs;
    
    public void RaiseAction()
    {
        raiseNoArgs?.Invoke();
    }

    public void RaiseAction(Object obj)
    {
        raise?.Invoke(obj);
    }

    public void RaiseAction(float obj)
    {
        raise?.Invoke(obj);
    }
    
    public void RaiseAction(int obj)
    {
        raise?.Invoke(obj);
    }

    public void RaiseAction(Transform obj)
    {
        raise?.Invoke(obj);
    }

    public void RaiseAction(Coroutine obj)
    {
        raiseCoroutine?.Invoke(obj);
    }
}