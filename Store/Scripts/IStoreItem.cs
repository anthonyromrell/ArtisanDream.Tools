using UnityEngine;
public interface IStoreItem
{
    public int Price { get; set; }
    public bool Purchased { get; set; }
    public Sprite PreviewArt { get; set; }
    
    public string Name { get; set; }
}