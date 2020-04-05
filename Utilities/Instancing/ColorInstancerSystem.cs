using UnityEngine;

[CreateAssetMenu(menuName = "System/Generator")]
public class ColorInstancerSystem : InstancerSystemBase
{
    public ColorDataCollection collection;
    public override void ConfigureInstance(GameObject newObj)
    {
        collection.RandomizeIndex();
        var spriteRenderer = newObj.GetComponent<SpriteRenderer>();
        spriteRenderer.color = collection.ReturnColorData().value;
    }
}