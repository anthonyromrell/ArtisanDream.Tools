using UnityEngine;

/// <summary>
/// The SimpleCharacterController class controls basic movement of a 2D platformer character.
/// This includes horizontal movement and jumping, adding gravity, and maintaining character position on the x-axis.
/// </summary>
[Tooltip("Controls basic movement of a 2D platformer character.")]
[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    [Tooltip("The speed at which the character moves horizontally.")]
    public float moveSpeed = 5f;

    [Tooltip("The upward force applied when the character jumps.")]
    public float jumpForce = 4f;

    [Tooltip("The constant downward force applied by gravity.")]
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
    //add a roll to the character controller
   
    

    /// <summary>
    /// Initialize required components.
    /// </summary>
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    /// <summary>
    /// Controls character movement and position every frame.
    /// </summary>
    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    /// <summary>
    /// Handles horizontal movement and jumping.
    /// </summary>
    private void MoveCharacter()
    {
        // Handle horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    /// <summary>
    /// Defines the character's behavior under gravity.
    /// </summary>
    private void ApplyGravity()
    {
        // Apply gravity when off the ground
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Reset vertical velocity when on the ground
            velocity.y = 0f;
        }

        // Apply velocity
        controller.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// Ensures the character remains on the x-axis.
    /// </summary>
    private void KeepCharacterOnXAxis()
    {
        // Lock the z-axis position to maintain 2D movement
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}