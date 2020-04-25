using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimateCharacter : MonoBehaviour
{

    public UnityEvent startEvent, jumpEvent, triggerEnterEvent, triggerExitEvent, fireWeaponEvent;
    private Animator characterAnim;
    public GameAction jumpAction;
    public GameAction moveSpeedAction;
    public GameAction fireWeapon;
    private readonly int fireWeaponString = Animator.StringToHash("FireWeapon");
    private readonly int walkString = Animator.StringToHash("Walk");

    private void Start()
    {
        characterAnim = GetComponent<Animator>();
        jumpAction.raiseNoArgs += Jump;
        moveSpeedAction.raise += Walk;
        startEvent.Invoke();
    }

    private void FireHandler()
    {
        characterAnim.SetLayerWeight(1, 1);
        characterAnim.SetTrigger(fireWeaponString);
    }

    public void OnFire()
    {
        fireWeaponEvent.Invoke();
    }
    

    public void EndFireWeapon()
    {
        //CurrentWeaponData.WeaponObject.Fire(false);
    }

    private void Walk(object speed)
    {
        var newSpeed = (float) speed;
        characterAnim.SetFloat(walkString, newSpeed);
    }

    private void Jump()
    {
        jumpEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}