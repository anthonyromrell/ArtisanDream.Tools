using UnityEngine;

[CreateAssetMenu]
public class Destroyer : ScriptableObject
{
    public void DestroyObj (Object obj)
    {
        Destroy(obj);
    }
}