using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action Advanced")]
public class GameActionAdvanced : GameAction
{
    public GameActionAdvanced(UnityAction<Coroutine> raiseCoroutine)
    {
        RaiseCoroutine = raiseCoroutine;
    }
    public UnityAction<object> Raise { get; set; }

    private UnityAction<Coroutine> RaiseCoroutine { get; set; }
    
    public void RaiseAction(Object obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(float obj)
    {
        Raise?.Invoke(obj);
    }
    
    public void RaiseAction(int obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(Transform obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(Coroutine obj)
    {
        RaiseCoroutine?.Invoke(obj);
    }
}
