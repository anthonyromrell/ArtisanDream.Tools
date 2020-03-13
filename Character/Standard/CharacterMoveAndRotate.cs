using UnityEngine;

[CreateAssetMenu(menuName = "Character Patterns/Move And Rotate")]
public class CharacterMoveAndRotate : CharacterPattern
{

    public Vector3 rotateDirection;
    public float rotateSpeed = 10;

    public override void Call(CharacterController controller)
    {
        positionDirection.Set(0,0,speed*Input.GetAxis(vAxis));
        rotateDirection.y = rotateSpeed * Input.GetAxis(hAxis);
        controller.transform.Rotate(rotateDirection);
        positionDirection = controller.transform.TransformDirection(positionDirection);

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
