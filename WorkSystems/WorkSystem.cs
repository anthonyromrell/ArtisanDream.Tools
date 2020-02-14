using UnityEngine;

public abstract class WorkSystem : ScriptableObject
{
    public NameId NameIdObj { get; set; }
    public abstract void Work();
}