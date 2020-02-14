using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Trigger Chase", menuName = "Ai/Function/Trigger Chase")]

public class AiTriggerChase : AiHunt
{
    [FormerlySerializedAs("GetTransformAction")] public GameAction getTransformAction;

    protected override void OnEnable()
    {
        base.OnEnable();
        getTransformAction.raise += Raise;
    }
}