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
    
    public override void Call(CharacterController controller)
    {
        switch (Axis)
        {
            case MoveAxis.X:
                positionDirection.Set(speed,0,0 );
                break;
            case MoveAxis.Y:
                positionDirection.Set(0,speed,0 );
                break;
            case MoveAxis.Z:
                positionDirection.Set(0,0,speed );
                break;
        }
        controller.Move(positionDirection*Time.deltaTime);
    }
}
