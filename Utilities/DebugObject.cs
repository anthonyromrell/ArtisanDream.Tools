using UnityEngine;

[CreateAssetMenu(fileName = "DebugObject", menuName = "Objects/Debug Object")]
public class DebugObject : WorkSystem, ICall
{
    [SerializeField] private string value;

    public string Value
    {
        private get { return value; }
        set { this.value = value; }
    }

    public void Call()
    {
        Debug.Log("It worked");
    }

    public override void Work()
    {
        Call();
    }
}