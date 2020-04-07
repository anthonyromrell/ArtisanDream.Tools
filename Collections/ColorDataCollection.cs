using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Collections/ColorDataList")]
public class ColorDataCollection : InstanceConfigBase, ICollectList
{
    public List<ColorData> colorDataList;
    public int Index { get; set; }
    public List<Object> CollectionList { get; set; }

    private void OnEnable()
    {
        CollectionList.Clear();
        foreach (var obj in colorDataList)
        {
            CollectionList.Add(obj);
        }
    }

    public void RandomizeIndex()
    {
        Index = Random.Range(0, colorDataList.Count);
    }

    public override void ConfigureInstance(GameObject instance)
    {
        var id = (NameId) colorDataList[Index];
        var idComponent = instance.GetComponent<IdBehaviour>();
        if (idComponent == null) return;
        idComponent.nameIdObj = id;
        instance.name += id.name;

        // if (instance.GetComponentInChildren<SpriteRenderer>() != null)
        // {
        var spriteRenderer = instance.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = colorDataList[Index].value;
        //}

        // if (instance.GetComponent<Renderer>().material != null)
        // {
        //     var material = instance.GetComponent<Renderer>().material;
        //     material.color = colorDataList[Index].value;
        // }
    }
}