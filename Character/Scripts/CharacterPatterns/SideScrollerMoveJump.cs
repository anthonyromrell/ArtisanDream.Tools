using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/SideScroller")]
public class SideScrollerMoveJump : CharacterPattern
{
    public string axis = "Horizontal";
    public override void Move(CharacterController controller)
    {
        positionDirection.x = Input.GetAxis(axis)*Speed;
        
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
        
        positionDirection.y -= gravity*Time.deltaTime;
        controller.Move(positionDirection*Time.deltaTime);
    }
    // Function to rotate the character
    
}