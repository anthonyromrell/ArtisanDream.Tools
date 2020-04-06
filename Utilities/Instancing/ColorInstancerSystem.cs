using UnityEngine;

[CreateAssetMenu(menuName = "System/Generator")]
public class ColorInstancerSystem : InstancerSystemBase
{
    public ColorDataCollection collection;
    public override void ConfigureInstance(GameObject instance)
    {
        collection.RandomizeIndex();
        var spriteRenderer = instance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = collection.ReturnColorData().value;
    }
}