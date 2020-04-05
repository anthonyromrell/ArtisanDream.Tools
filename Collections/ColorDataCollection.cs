using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/ColorDataList")]
public class ColorDataCollection : ScriptableObject
{
    public List<ColorData> ColorDatas;
    public int index;

    public void RandomizeIndex()
    {
        index = Random.Range(0, ColorDatas.Count);
        Debug.Log(index);
    }

    public ColorData ReturnColorData()
    {
        return ColorDatas[index];
    }
    
    public ColorData ReturnRandomColorData()
    {
        RandomizeIndex();
        return ColorDatas[index];
    }
}
