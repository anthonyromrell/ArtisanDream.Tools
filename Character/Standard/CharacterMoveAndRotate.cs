using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoveAndRotate : CharacterBehaviour
{

    public Vector3 rotateDirection;
    public float rotateSpeed = 10;
    
    void Update()
    {
        positionDirection.Set(0,0,speed*Input.GetAxis(vAxis));
        rotateDirection.y = rotateSpeed * Input.GetAxis(hAxis);
        transform.Rotate(rotateDirection);
        positionDirection = transform.TransformDirection(positionDirection);

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
        
        
        controller.Move(positionDirection * Time.deltaTime);
    }
}
