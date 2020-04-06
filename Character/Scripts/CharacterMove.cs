using UnityEngine;

[CreateAssetMenu(menuName = ("Character Patterns/Character Move"))]
public class CharacterMove : CharacterPattern
{
    public override void Call( CharacterController controller)
    {
        positionDirection.x = Input.GetAxis("Horizontal")*speed;

        if (controller.isGrounded)
        {
            positionDirection.y = 0;
            jumpCount = 0;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
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