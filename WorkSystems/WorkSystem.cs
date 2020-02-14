using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class WorkSystem : ScriptableObject
{
    public NameId NameIdObj { get; set; }
    public UnityEvent workEvent;
    public abstract void Work();
}