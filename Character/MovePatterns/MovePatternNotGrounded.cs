using UnityEngine;

[CreateAssetMenu(menuName = "Character/MovePattern NotGrounded")]
public class MovePatternNotGrounded : MovePattern
{
    public override void Call(CharacterController controller, Transform transform)
    {
        Move(transform);
        Move(controller);
    }
}