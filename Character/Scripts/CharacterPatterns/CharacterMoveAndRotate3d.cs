using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/Move And Rotate")]
public class CharacterMoveAndRotate3d : CharacterPattern
{

    public Vector3 rotateDirection;
    public float rotateSpeed = 10;

    public override void Move(CharacterController controller)
    {
        PositionDirection.Set(0,0,Speed*Input.GetAxis(vAxis));
        rotateDirection.y = rotateSpeed * Input.GetAxis(hAxis);
        controller.transform.Rotate(rotateDirection);
        PositionDirection = controller.transform.TransformDirection(PositionDirection);

        if (controller.isGrounded)
        {
            PositionDirection.y = 0;
            jumpCount = 0;
        }
        
        if (jumpCount < jumpCountMax && Input.GetButtonDown("Jump"))
        {
            PositionDirection.y = jumpForce;
            jumpCount++;
        }
        
        PositionDirection.y -= gravity;
        
        
        controller.Move(PositionDirection * Time.deltaTime);
    }
}
