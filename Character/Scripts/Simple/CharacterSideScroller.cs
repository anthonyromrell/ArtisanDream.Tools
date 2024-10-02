using UnityEngine;

public class CharacterSideScroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 4f;
    public float gravity = -9.81f;
    public int maxJumps = 2;

    private CharacterController controller;
    private Vector3 velocity;
    private int jumpsRemaining;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Calling our methods
        HorizontalMovement();
        ApplyGravity();
        Jump();
        SetZPositionToZero();

        // Apply all movement
        controller.Move(velocity * Time.deltaTime);
    }

    private void HorizontalMovement()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var moveDirection = new Vector3(moveInput, 0f, 0f) * moveSpeed;
        velocity.x = moveDirection.x;
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
            jumpsRemaining = maxJumps;
        }
    }

    private void Jump()
    {
        if (!Input.GetButton("Jump") || (!controller.isGrounded && jumpsRemaining <= 0)) return;
        velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        jumpsRemaining--;
    }

    private void SetZPositionToZero()
    {
        var transform1 = transform;
        var position = transform1.position;
        position.z = 0;
        transform1.position = position;
    }
}