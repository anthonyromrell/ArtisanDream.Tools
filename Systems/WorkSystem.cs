using UnityEngine;
using UnityEngine.Events;

public abstract class WorkSystem : ScriptableObject
{
    public NameId NameIdObj { get; set; }
    public UnityEvent workEvent;
    public abstract void Work();
}