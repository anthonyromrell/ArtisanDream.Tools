using UnityEngine;

[CreateAssetMenu(menuName = ("Character Patterns/Character Move"))]
public class CharacterMove2d : CharacterPattern
{
    public override void Move( CharacterController controller)
    {
        positionDirection.x = Input.GetAxis("Horizontal")*Speed;

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
        
        if (!Input.anyKey)
        {
            positionDirection.x = 0f;
        }
  
        controller.Move(positionDirection*Time.deltaTime);
    }
}