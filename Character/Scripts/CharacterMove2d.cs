using UnityEngine;

[CreateAssetMenu(menuName = ("Character Patterns/Character Move"))]
public class CharacterMove2d : CharacterPattern
{
    public override void Move( CharacterController controller)
    {
        PositionDirection.x = Input.GetAxis("Horizontal")*Speed;

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
        
        if (!Input.anyKey)
        {
            PositionDirection.x = 0f;
        }
  
        controller.Move(PositionDirection*Time.deltaTime);
    }
}