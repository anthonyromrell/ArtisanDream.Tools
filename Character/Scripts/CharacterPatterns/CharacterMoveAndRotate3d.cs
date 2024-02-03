using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/Move And Rotate")]
public class CharacterMoveAndRotate3d : CharacterPattern
{

    public Vector3 rotateDirection;
    public float rotateSpeed = 10;

    public override void Move(CharacterController controller)
    {
        positionDirection.Set(0,0,Speed*Input.GetAxis(vAxis));
        rotateDirection.y = rotateSpeed * Input.GetAxis(hAxis);
        controller.transform.Rotate(rotateDirection);
        positionDirection = controller.transform.TransformDirection(positionDirection);

        if (controller.isGrounded)
        {
            positionDirection.y = 0;
            jumpCount = 0;
        }
        
        if (jumpCount < jumpCountMax && Input.GetButtonDown("Jump"))
        {
            positionDirection.y = jumpForce;
            jumpCount++;
        }
        
        positionDirection.y -= gravity;
        
        
        controller.Move(positionDirection * Time.deltaTime);
    }
}
