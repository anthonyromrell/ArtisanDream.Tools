using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Collectable")]
public class Collectible : NameID
{
    public int value;
    public GameObject art;
    public Sprite sprite;
    public Color color;
    public virtual void Use()
    {
        Debug.Log("Collected");
    }
}