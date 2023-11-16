using System.Collections.Generic;
using UnityEngine;

public interface ICollectList<T> where T : Object
{
    int Index { get; set; }
    List<T> CollectionList { get; set; }
    void ConfigureInstance(GameObject instance);
}


public interface IStoreItem
{
    int Price { get; set; }
    bool Purchased { get; set; }
    bool CanUse { get; set; }
    Sprite PreviewArt { get; set; }
    string Name { get; set; }
}


public interface IInventoryItem
{
    bool Used { get; set; }
    int IntLevel { get; set; }
    float FloatLevel { get; set; }
    Sprite PreviewArt { get; set; }
    GameObject GameArt { get; set; }
    string Name { get; set; }
    
    public GameAction GameActionObj { get; set; }
    void Raise();
}

public interface IGameAction<T>
{
    public GameAction GameActionObj { get; set; }
    void Raise(T obj);
}
