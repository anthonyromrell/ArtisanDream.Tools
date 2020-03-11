using UnityEngine;

[CreateAssetMenu(fileName = "DebugObject", menuName = "Utilities/Debug Object")]
public class Debugger : ScriptableObject
{
    [SerializeField] private string value;

    public string Value
    {
        private get { return value; }
        set { this.value = value; }
    }
}