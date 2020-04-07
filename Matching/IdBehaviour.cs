using JetBrains.Annotations;
using UnityEngine;

public class IdBehaviour : MonoBehaviour
{
    [CanBeNull] public NameId nameIdObj;

    public void ChangeId(NameId id)
    {
        nameIdObj = id;
    }
}