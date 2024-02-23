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
    bool UsedOrPurchase { get; set; }
    Sprite PreviewArt { get; set; }
    string ThisName { get; set; }
    PurchaseType.Type ItemPurchaseType { get; set; }
}


public interface IInventoryItem
{
    bool UsedOrPurchase { get; set; }
    int IntLevel { get; set; }
    float FloatLevel { get; set; }
    Sprite PreviewArt { get; set; }
    GameObject GameArt { get; set; }
    string ThisName { get; set; }

    GameAction GameActionObj { get; set; }
    void Raise();
}

public interface IGameAction<T>
{
    GameAction GameActionObj { get; set; }
    void Raise(T obj);
}
