using UnityEngine;

[CreateAssetMenu(fileName = "DebugObject", menuName = "Objects/Debug Object")]
public class DebugObject : ScriptableObject
{
    public void Call(string s)
    {
        Debug.Log(s);
    }
}