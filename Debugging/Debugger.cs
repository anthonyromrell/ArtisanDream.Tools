using UnityEngine;

[CreateAssetMenu(menuName = "Utilities/Debugger")]
public class Debugger : ScriptableObject
{
    public void OnDebug(string message)
    {
        Debug.Log(message);
    }
}