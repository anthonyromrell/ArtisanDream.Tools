using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/StringData")]
public class StringData : ScriptableObject
{
    [FormerlySerializedAs("Value")] public string value;
    public string SingleName { get; set; }
}