using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction RaiseNoArgs { get; set; }

    public void Raise()
    {
        RaiseNoArgs?.Invoke();
    }
}