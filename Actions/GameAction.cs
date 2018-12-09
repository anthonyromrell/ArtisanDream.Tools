using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> Raise;
    public UnityAction<Coroutine> RaiseCoroutine;
    public UnityAction RaiseNoArgs;

    //Overloading
    public void RaiseAction()
    {
        RaiseNoArgs();
    }

    public void RaiseAction(Object obj)
    {
        Raise(obj);
    }

    public void RaiseAction(float obj)
    {
        Raise(obj);
    }
    
    public void RaiseAction(int obj)
    {
        Raise(obj);
    }

    public void RaiseAction(Transform obj)
    {
        Raise(obj);
    }

    public void RaiseAction(Coroutine obj)
    {
        RaiseCoroutine(obj);
    }
}