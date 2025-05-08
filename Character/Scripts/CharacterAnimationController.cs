using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public CharacterController controller;
    private Animator animator;
    private readonly int 
        run = Animator.StringToHash("Run"),
        idle = Animator.StringToHash("Idle"),
        jump = Animator.StringToHash("Jump"),
        wallJump = Animator.StringToHash("WallJump");

    private void Start()
    {
        // Cache the Animator component attached to CharacterArt
        animator = GetComponent<Animator>();
        //controller in parent object
        controller = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            animator.SetBool(jump, true);
        }
        else if (controller.isGrounded && animator.GetBool("Jump"))
        {
            animator.SetBool(jump, false);
        }

        if (Mathf.Abs(horizontalMove) > 0)
        {
            animator.SetBool(run, true);
            animator.SetBool(idle, false);
        }
        else
        {
            animator.SetBool(run, false);
            animator.SetBool(idle, true);
        }
    }
}