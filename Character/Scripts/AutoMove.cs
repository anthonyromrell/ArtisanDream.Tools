using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/AutoMove")]
public class AutoMove : CharacterPattern
{
    public enum MoveAxis
    {
        X, Y,Z
    }

    public MoveAxis axis;
    
    public override void Move(CharacterController controller)
    {
        switch (axis)
        {
            case MoveAxis.X:
                PositionDirection.Set(Speed,0,0 );
                break;
            case MoveAxis.Y:
                PositionDirection.Set(0,Speed,0 );
                break;
            case MoveAxis.Z:
                PositionDirection.Set(0,0,Speed );
                break;
        }
        controller.Move(PositionDirection*Time.deltaTime);
    }
}
