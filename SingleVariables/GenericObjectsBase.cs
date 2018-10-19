using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class GenericObjectsBase<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T obj)
    {
        if (!Items.Contains(obj))
            Items.Add(obj);
    }

    public void Remove(T obj)
    {
        if (Items.Contains(obj))
            Items.Remove(obj);
    }
}