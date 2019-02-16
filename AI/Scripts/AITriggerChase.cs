using UnityEngine;

[CreateAssetMenu(fileName = "Trigger Chase", menuName = "Ai/Function/Trigger Chase")]

public class AITriggerChase : AiHunt
{
    public GameAction GetTransformAction;

    protected override void OnEnable()
    {
        base.OnEnable();
        GetTransformAction.Raise += Raise;
    }
}