using JetBrains.Annotations;
using UnityEngine;

public class IdBehaviour : MonoBehaviour
{
    [CanBeNull] public NameID nameIdObj;

    public void ChangeId(NameID id)
    {
        nameIdObj = id;
    }
}