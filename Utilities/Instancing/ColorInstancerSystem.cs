using UnityEngine;

[CreateAssetMenu(menuName = "System/Generator")]
public class ColorInstancerSystem : InstancerSystemBase
{
    public ColorDataCollection collection;

    public void RadomizeCollectionIndex()
    {
        collection.RandomizeIndex();
    }
    public override void ConfigureInstance(GameObject instance)
    {
        var spriteRenderer = instance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = collection.ReturnColorData().value;
    }
}