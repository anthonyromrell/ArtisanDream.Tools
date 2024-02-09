using UnityEngine;
using UnityEngine.Events;

public abstract class WorkSystem : ScriptableObject
{
    protected NameId NameIdObj { get;}
    public UnityEvent workEvent;

    protected WorkSystem(NameId nameIdObj)
    {
        NameIdObj = nameIdObj;
    }

    public abstract void Work();
}