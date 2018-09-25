using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> Call;
    public UnityAction CallNoArgs;

    //Overloading
    public void ActionCall()
    {
        CallNoArgs();
    }

    public void ActionCall(object obj)
    {
        Call(obj);
    }

    public void ActionCall(float obj)
    {
        Call(obj);
    }

    public void ActionCall(Transform obj)
    {
        Call(obj);
    }
}