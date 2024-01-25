using UnityEngine;
using UnityEngine.Events;

public class AnimStatesBehaviour : StateMachineBehaviour
{
    public GameAction onEnterStateAction, onExitStateAction, onStateUpdateAction, onStateMoveAction, onStateIKAction;
    public UnityEvent onEnterStateEvent, onExitStateEvent, onStateUpdateEvent, onStateMoveEvent, onStateIKEvent;
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onEnterStateEvent.Invoke();
        if (onEnterStateAction != null) onEnterStateAction.RaiseNoArgs();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    onExitStateEvent.Invoke();
    //    if (onEnterStateAction != null) onExitStateAction?.Raise();
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    onStateUpdateEvent.Invoke();
    //    if (onEnterStateAction != null) onStateUpdateAction?.Raise();
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    onStateMoveEvent.Invoke();
    //    if (onEnterStateAction != null) onStateMoveAction?.Raise();
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    onStateIKEvent.Invoke();
    //    if (onEnterStateAction != null) onStateIKAction?.Raise();
    //}
}
