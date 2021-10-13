using UnityEngine;

[CreateAssetMenu]
public class ApplicationControl : ScriptableObject
{
    public void QuiteGame()
    {
        Application.Quit();
    }
}
