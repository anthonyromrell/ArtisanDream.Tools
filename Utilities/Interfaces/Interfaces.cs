using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICollectList
{
    int Index { get; set; }
    List<Object> CollectionList { get; set; }
    void ConfigureInstance(GameObject instance);
}

public interface IPowerUp
{
    public float PowerLevel { get; set; }
}

public interface IPool
{
    public void AddToPool(GameObject obj);
}

public abstract class IGameAction
{
    public UnityAction raise;
}