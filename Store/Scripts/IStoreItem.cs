using UnityEngine;
public interface IStoreItem
{
    public int Price { get; set; }
    public bool Purchased { get; set; }
    public bool CanUse { get; set; }
    public Sprite PreviewArt { get; set; }
    
    public string Name { get; set; }
}

public interface IInventoryItem
{
    public bool Used { get; set; }
    public int IntLevel { get; set; }
    public int FloatLevel { get; set; }
    public Sprite PreviewArt { get; set; }
    
    public GameObject GameArt { get; set; }
    public string Name { get; set; }
}