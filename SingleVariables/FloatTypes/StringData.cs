using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/StringData")]
public class StringData : ScriptableObject
{
    public string Value;
    public string SingleName { get; set; }
}