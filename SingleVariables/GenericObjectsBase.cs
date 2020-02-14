using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public abstract class GenericObjectsBase<T> : ScriptableObject
{
    [FormerlySerializedAs("Items")] public List<T> items = new List<T>();

    public void Add(T obj)
    {
        if (!items.Contains(obj))
            items.Add(obj);
    }

    public void Remove(T obj)
    {
        if (items.Contains(obj))
            items.Remove(obj);
    }
}