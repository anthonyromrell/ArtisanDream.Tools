using System.Collections;
using UnityEngine;

public class CollectionUI : MonoBehaviour
{
    public Collection collection;
    private WaitForSeconds wfs;
    public float holdTime = 0.2f;

    public void StartBuild(Transform obj)
    {
        wfs = new WaitForSeconds(holdTime);
        StartCoroutine(BuildCollectionLayout(obj));
    }
    private IEnumerator BuildCollectionLayout(Transform obj)
    {
        foreach (var collectable in collection.collectablesList)
        {
            yield return wfs;
            var newPanel = Instantiate(collection.layoutObject, obj);
            newPanel.collectable = collectable;
            newPanel.cash = collection.cash;
        }
    }
}