using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    [FormerlySerializedAs("Raise")] public UnityAction<object> raise;
    [FormerlySerializedAs("RaiseCoroutine")] public UnityAction<Coroutine> raiseCoroutine;
    [FormerlySerializedAs("RaiseNoArgs")] public UnityAction raiseNoArgs;

    //Overloading
    public void RaiseAction()
    {
        raiseNoArgs();
    }

    public void RaiseAction(Object obj)
    {
        raise(obj);
    }

    public void RaiseAction(float obj)
    {
        raise(obj);
    }
    
    public void RaiseAction(int obj)
    {
        raise(obj);
    }

    public void RaiseAction(Transform obj)
    {
        raise(obj);
    }

    public void RaiseAction(Coroutine obj)
    {
        raiseCoroutine(obj);
    }
}