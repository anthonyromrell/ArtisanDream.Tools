using System.Collections.Generic;
using UnityEngine;

public class CollectionBase : ScriptableObject
{
    public int index;
    public List<Collectible> collectibles;

    public void RandomizeIndex()
    {
        index = Random.Range(0, collectibles.Count - 1);
    }
    
    public void RandomizeIndex(int maxNumber)
    {
        index = Random.Range(0, maxNumber);
    }
    
    public void RandomizeIndex(CollectionBase collectionBase)
    {
        index = Random.Range(0, collectionBase.collectibles.Count - 1);
    }
}