using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/AutoMove")]
public class AutoMove : CharacterPattern
{
    public enum MoveAxis
    {
        X, Y, Z
    }

    public MoveAxis axis;
    public float rotationSpeed = 0f;

    public override void Move(CharacterController controller)
    {
        var rotation = new Vector3(0f, rotationSpeed * Time.deltaTime, 0f);
        controller.transform.Rotate(rotation);

        switch (axis)
        {
            case MoveAxis.X:
                PositionDirection.Set(speed, 0, 0);
                break;
            case MoveAxis.Y:
                PositionDirection.Set(0, speed, 0);
                break;
            case MoveAxis.Z:
                PositionDirection.Set(0, 0, speed);
                break;
            default:
                PositionDirection.Set(speed, 0, 0);
                break;
        }
        PositionDirection = controller.transform.TransformDirection(PositionDirection);
        controller.Move(PositionDirection * Time.deltaTime);
    }
}