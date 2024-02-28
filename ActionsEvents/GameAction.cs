using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> Raise { get; set; }

    public UnityAction RaiseNoArgs { get; set; }

    public void RaiseAction()
    {
        RaiseNoArgs?.Invoke();
    }

    public void RaiseAction<T>(T obj)
    {
        Raise?.Invoke(obj);
    }
}