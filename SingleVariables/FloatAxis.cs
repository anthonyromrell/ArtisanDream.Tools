using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FloatAxis")]
public class FloatAxis : FloatData
{
    [SerializeField] private string axis = "Horizontal";
}