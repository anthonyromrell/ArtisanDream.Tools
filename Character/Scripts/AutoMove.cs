using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/AutoMove")]
public class AutoMove : CharacterPattern
{
    public enum MoveAxis
    {
        X, Y,Z
    }

    public MoveAxis Axis;
    
    public override void Move(CharacterController controller)
    {
        switch (Axis)
        {
            case MoveAxis.X:
                PositionDirection.Set(speed,0,0 );
                break;
            case MoveAxis.Y:
                PositionDirection.Set(0,speed,0 );
                break;
            case MoveAxis.Z:
                PositionDirection.Set(0,0,speed );
                break;
        }
        controller.Move(PositionDirection*Time.deltaTime);
    }
}
