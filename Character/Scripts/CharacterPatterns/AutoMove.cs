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
                positionDirection.Set(Speed,0,0 );
                break;
            case MoveAxis.Y:
                positionDirection.Set(0,Speed,0 );
                break;
            case MoveAxis.Z:
                positionDirection.Set(0,0,Speed );
                break;
        }
        controller.Move(positionDirection*Time.deltaTime);
    }
}
