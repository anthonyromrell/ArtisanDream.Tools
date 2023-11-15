using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Collection")]
public class Collection : CollectionBase
{
  public void AddToCollection(Collectible collectibleObj)
  {
    if (collectibles.Contains(collectibleObj))
      return;
    collectibles.Add(collectibleObj);
  }

  public void RemoveFromCollection(Collectible collectibleObj)
  {
    for (var index = collectibles.Count - 1; index >= 0; index--)
    {
      var obj = collectibles[index];
      if (obj == collectibleObj)
      {
        collectibles.Remove(collectibleObj);
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