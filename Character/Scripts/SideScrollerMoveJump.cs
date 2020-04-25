using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/SideScroller")]
public class SideScrollerMoveJump : CharacterPattern
{
    public override void Call(CharacterController controller)
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
        
        positionDirection.y -= gravity*Time.deltaTime;
        controller.Move(positionDirection*Time.deltaTime);
    }
}