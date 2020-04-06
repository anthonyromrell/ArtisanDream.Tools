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
        var data = collection.ReturnColorData();
        var spriteRenderer = instance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = data.value;

        var id = (NameId) data;
        var idComponent = instance.GetComponent<IdBehaviour>();
        idComponent.nameIdObj = id;
        instance.name += id.name;
    }
}