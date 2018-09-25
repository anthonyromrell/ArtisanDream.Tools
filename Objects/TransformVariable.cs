using UnityEngine;

[CreateAssetMenu(fileName = "TransformVariable")]
public class TransformVariable : ScriptableObject
{
    public Transform Value { get; set; }
}