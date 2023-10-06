using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> raise;
    public UnityAction<Coroutine> raiseCoroutine;
    public UnityAction raiseNoArgs;
    
    
    public void Raise()
    {
        raiseNoArgs?.Invoke();
    }
    public void Raise(object obj)
    {
        raise?.Invoke(obj);
    }

    public void Raise(float obj)
    {
        raise?.Invoke(obj);
    }
    
    public void Raise(int obj)
    {
        raise?.Invoke(obj);
    }

    public void Raise(Transform obj)
    {
        raise?.Invoke(obj);
    }
    
    public void Raise(GameObject obj)
    {
        raiseCoroutine?.Invoke(obj);
    }
}