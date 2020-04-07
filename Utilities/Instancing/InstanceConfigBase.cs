using UnityEngine;

public abstract class InstanceConfigBase : ScriptableObject
{
    public abstract void ConfigureInstance(GameObject instance);
}