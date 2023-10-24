using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/SideScroller")]
public class SideScrollerMoveJump : CharacterPattern
{
    public string axis = "Horizontal";
    public override void Move(CharacterController controller)
    {
        PositionDirection.x = Input.GetAxis(axis)*Speed;
        
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
        
        PositionDirection.y -= gravity*Time.deltaTime;
        controller.Move(PositionDirection*Time.deltaTime);
    }
}