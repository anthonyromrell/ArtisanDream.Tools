using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterSideScroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 4f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        var moveDirection = new Vector3(moveInput, 0f, 0f) * moveSpeed;

        // Apply gravity
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }

        // Jumping
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        // Apply movement and handle collisions
        var move = moveDirection + velocity;
        controller.Move(move * Time.deltaTime);

        // Set the character's Z position to 0
        var transform1 = transform;
        var newPosition = transform1.position;
        newPosition.z = 0;
        transform1.position = newPosition;
    }
}