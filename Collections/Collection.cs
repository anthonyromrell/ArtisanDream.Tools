using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collection : ScriptableObject
{
  public List<Collectable> collectablesList;
  public int currentCollectableNum;
  
  public void AddToCollection(Collectable collectableObj)
  {
    if (collectablesList.Contains(collectableObj))
      return;
    collectablesList.Add(collectableObj);
  }

  public void RemoveFromCollection(Collectable collectableObj)
  {
    for (var index = collectablesList.Count - 1; index >= 0; index--)
    {
      var obj = collectablesList[index];
      if (obj == collectableObj)
      {
        collectablesList.Remove(collectableObj);
      }
    }
  }

  public void ClearCollection()
  {
    collectablesList.Clear();
  }

  public void UseCurrentItem()
  {
    if (collectablesList.Capacity > 0)
    {
      collectablesList[currentCollectableNum].Use();
    }
  }

  public void IncrementCurrentNum()
  {
    if (currentCollectableNum < collectablesList.Count -1)
    {
      currentCollectableNum++;
    }
    else
    {
      currentCollectableNum = 0;
    }
  }
}