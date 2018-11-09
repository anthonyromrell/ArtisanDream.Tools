using UnityEngine;

//Made By Anthony Romrell
[CreateAssetMenu(menuName = "Character/MovePattern")]
public class MovePattern : ScriptableObject
{
    public FloatData Gravity;

    public FloatData MoveX, MoveY, MoveZ;
    public FloatData RotX, RotY, RotZ;

    protected Vector3 MoveDirection;
    private Vector3 rotDirection;

    private void OnEnable()
    {
        MoveDirection = Vector3.zero;
        rotDirection = Vector3.zero;
    }

    public virtual void Call(CharacterController controller, Transform transform)
    {
        if (controller.isGrounded)
        {
            MoveDirection.Set(MoveX.Value, MoveY.Value, MoveZ.Value);
            rotDirection.Set(RotX.Value, RotY.Value, RotZ.Value);
            transform.Rotate(rotDirection);
            MoveDirection = transform.TransformDirection(MoveDirection);
        }

        MoveDirection.y -= Gravity.Value;
        controller.Move(MoveDirection * Time.deltaTime);
    }

    protected void Move(Transform transform)
    {
        MoveDirection.Set(MoveX.Value, MoveY.Value, MoveZ.Value);
        rotDirection.Set(RotX.Value, RotY.Value, RotZ.Value);
        transform.Rotate(rotDirection);
        MoveDirection = transform.TransformDirection(MoveDirection);
    }

    protected void Move(CharacterController controller)
    {
        MoveDirection.y = Gravity.Value;
        Debug.Log(MoveDirection.y);
        controller.Move(MoveDirection * Time.deltaTime);
    }
}