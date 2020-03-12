using UnityEngine;

public class CharacterMover : CharacterBehaviour
{
    void Update()
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
        controller.Move(positionDirection*Time.deltaTime);
    }
}