using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Collections/ColorDataList")]
public class ColorDataCollection : ScriptableObject, ICollectList<ColorData>
{
    public List<ColorData> colorDataList;
    public int Index { get; set; }
    public List<ColorData> CollectionList { get; set; } = new List<ColorData>();

    private void OnEnable()
    {
        CollectionList.Clear();
        CollectionList.AddRange(colorDataList);
    }

    public void RandomizeIndex()
    {
        if (colorDataList.Count > 0)
        {
            Index = Random.Range(0, colorDataList.Count);
        }
    }

    public void ConfigureInstance(GameObject instance)
    {
        if (instance == null || Index < 0 || Index >= colorDataList.Count) return;

        var id = (NameId) colorDataList[Index];
        var idComponent = instance.GetComponentInChildren<IdBehaviour>();
        if (idComponent != null)
        {
            idComponent.nameIdObj = id;
        }

        instance.name = id.name; // Consider if you want to append or set the name

        var spriteRenderer = instance.GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorDataList[Index].Value;
        }
    }
}