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
        // add rotation from a float variable, apply it to the character controller
        Vector3 rotation = new Vector3(0f, rotationSpeed * Time.deltaTime, 0f);
        controller.transform.Rotate(rotation);

        switch (axis)
        {
            case MoveAxis.X:
                PositionDirection.Set(Speed, 0, 0);
                break;
            case MoveAxis.Y:
                PositionDirection.Set(0, Speed, 0);
                break;
            case MoveAxis.Z:
                PositionDirection.Set(0, 0, Speed);
                break;
        }
        PositionDirection = controller.transform.TransformDirection(PositionDirection);
        controller.Move(PositionDirection * Time.deltaTime);
    }
}