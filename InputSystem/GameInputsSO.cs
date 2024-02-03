using UnityEngine;

[CreateAssetMenu]
public class GameInputsSo : ScriptableObject
{
    public GameInputs gameInputsObj;

    private void OnEnable()
    {
        gameInputsObj = new GameInputs();
    }
}