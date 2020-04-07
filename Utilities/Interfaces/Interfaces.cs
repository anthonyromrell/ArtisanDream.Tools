using System.Collections.Generic;
using UnityEngine;

public interface ICollectList
{
    int Index { get; set; }
    List<Object> CollectionList { get; set; }
    void ConfigureInstance(GameObject instance);
}