using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    public CharacterPattern characterPattern;
    private WaitForFixedUpdate waitObj;
    public UnityEvent awakeEvent, triggerEnterEvent, triggerExitEvent;
    public bool CanRun { get; set; } = true;

    private void Awake()
    {
        awakeEvent.Invoke();
        waitObj = new WaitForFixedUpdate();
        controller = GetComponent<CharacterController>();
    }

    public void SwapPattern(CharacterPattern pattern)
    {
        characterPattern = pattern;
    }

    public void Restart()
    {
        //StartCoroutine(Start());
    }
    
    // private IEnumerator Start()
    // {
    //     CanRun = true;
    //     while (CanRun)
    //     {
    //         yield return waitObj;
    //         characterPattern.Move(controller);
    //     }
    // }

    public void LateUpdate()
    {
        characterPattern.Move(controller);
    }

    // public void Move(InputAction.CallbackContext context)
    // { 
    //     characterPattern.inputs = context.ReadValue<Vector2>();
    // }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}