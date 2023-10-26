using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    private bool isJumping;
    private readonly int idle = Animator.StringToHash("Idle");
    private readonly int walk = Animator.StringToHash("Walk");
    private readonly int jump = Animator.StringToHash("Jump");

    private void Update()
    {
        HandleInput();
        HandleJumpToIdle();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetTrigger(jump);
            isJumping = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger(walk);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetTrigger(idle);
        }
    }

    private void HandleJumpToIdle()
    {
        if (!isJumping || !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        animator.SetTrigger(idle);
        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(idle);
    }
}