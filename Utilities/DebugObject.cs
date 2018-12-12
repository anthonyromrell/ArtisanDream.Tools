using UnityEngine;

[CreateAssetMenu(fileName = "DebugObject", menuName = "Objects/Debug Object")]
public class DebugObject : ScriptableObject, ICall
{
    [SerializeField] private string value;

    public string Value
    {
        private get { return value; }
        set { this.value = value; }
    }

    public void Call()
    {
        Debug.Log(Value);
    }
}