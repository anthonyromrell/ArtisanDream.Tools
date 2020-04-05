using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Collection")]
public class Collection : CollectionBase
{
  public void AddToCollection(Collectable collectableObj)
  {
    if (collectibles.Contains(collectableObj))
      return;
    collectibles.Add(collectableObj);
  }

  public void RemoveFromCollection(Collectable collectableObj)
  {
    for (var index = collectibles.Count - 1; index >= 0; index--)
    {
      var obj = collectibles[index];
      if (obj == collectableObj)
      {
        collectibles.Remove(collectableObj);
      }
    }
  }

  public void ClearCollection()
  {
    collectibles.Clear();
  }

  public void UseCurrentItem()
  {
    if (collectibles.Capacity > 0)
    {
      collectibles[index].Use();
    }
  }

  public void IncrementCurrentNum()
  {
    if (index < collectibles.Count -1)
    {
      index++;
    }
    else
    {
      index = 0;
    }
  }
}