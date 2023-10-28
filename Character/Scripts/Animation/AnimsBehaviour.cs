using UnityEngine;

public class AnimsBehaviour : MonoBehaviour
{
    public Animator animator;
    private bool isArrowEventCall;
    private readonly int idle = Animator.StringToHash("Idle");
    private readonly int walk = Animator.StringToHash("Walk");
    private readonly int jump = Animator.StringToHash("Jump");
    private readonly int land = Animator.StringToHash("Land");

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.ResetTrigger(idle);
            animator.SetTrigger(walk);
            isArrowEventCall = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger(jump);
        }
        
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetTrigger(idle);
            isArrowEventCall = false;
        }

        if (isArrowEventCall) 
        {
            animator.SetTrigger(walk);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(land);
    }
    
    private void OnTriggerExit(Collider other)
    {
        animator.ResetTrigger(land);
    }
}
