using UnityEngine;
using UnityEngine.InputSystem;

public class TouchBehaviour : MonoBehaviour
{
    public GameInputsSO gameInputs;
    private TouchData touchData;
    private void Awake()
    {
        touchData = ScriptableObject.CreateInstance<TouchData>();
        gameInputs.gameInputsObj.mTouch.Contact.started += ContactOnStarted;
        gameInputs.gameInputsObj.mTouch.Contact.canceled += ContactOnCanceled;
    }
    private void OnEnable()
    {
        gameInputs.gameInputsObj.mTouch.Enable();
    }

    private void OnDisable()
    {
        gameInputs.gameInputsObj.mTouch.Disable();
    }

    private void ContactOnStarted(InputAction.CallbackContext ctx)
    {
        touchData.positionStart = gameInputs.gameInputsObj.mTouch.ContactPostion.ReadValue<Vector2>();
        Debug.Log(touchData.positionStart);
    }
    private void ContactOnCanceled(InputAction.CallbackContext ctx)
    {
        touchData.positionEnd = gameInputs.gameInputsObj.mTouch.ContactPostion.ReadValue<Vector2>();
        Debug.Log(touchData.positionEnd);
    }
}
