using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerHealth")]
public class Health : ScriptableObject
{
    public GameAction EndGameAction;

    public GameAction HealthAction;

    public Image HealthBarImage;
    [Range(0, 1)] public float HealthValue;

    private void OnEnable()
    {
        HealthAction.Call += HealthActionHandler;
    }

    private void HealthActionHandler(object obj)
    {
        HealthBarImage = obj as Image;
    }

    private void UpdateHealth(float powerLevel)
    {
        HealthBarImage.fillAmount += powerLevel;

        if (HealthBarImage.fillAmount < 0) EndGameAction.CallNoArgs();
    }
}