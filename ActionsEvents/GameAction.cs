using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public GameAction(UnityAction<Coroutine> raiseCoroutine)
    {
        RaiseCoroutine = raiseCoroutine;
    }
    public UnityAction<object> Raise { get; set; }

    private UnityAction<Coroutine> RaiseCoroutine { get; set; }

    public UnityAction RaiseNoArgs { get; set; }

    public void RaiseAction()
    {
        RaiseNoArgs?.Invoke();
    }
    public void Raise(object obj)
    {
        Raise?.Invoke(obj);
    }

    public void Raise(float obj)
    {
        Raise?.Invoke(obj);
    }
    
    public void Raise(int obj)
    {
        Raise?.Invoke(obj);
    }

    public void Raise(Transform obj)
    {
        Raise?.Invoke(obj);
    }
    
    public void Raise(Coroutine obj)
    {
        RaiseCoroutine?.Invoke(obj);
    }
}