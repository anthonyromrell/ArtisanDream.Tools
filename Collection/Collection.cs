using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Collection : ScriptableObject
{
    public IntData cash;
    public CollectablePanelBehaviour layoutObject;
    public List<Collectable> collectablesList;
}
