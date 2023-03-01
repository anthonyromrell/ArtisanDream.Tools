using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-5)]
public class TouchSwipeBehaviour : MonoBehaviour
{
    public GameInputsSO controls;
    public float minimumDistance = .2f, maximumTime = 1f;
    public UnityAction<Vector2, float> sendSwipeDirection, sendPrimaryPosition;
    
    private float timeStart, timeEnd, force;
    private Vector2 positionStart, positionEnd, direction, findDirection;
    private Camera cameraMain;
    private CameraUtility cameraUtility;
    
    private void Awake()
    {
        cameraMain = Camera.main;
        cameraUtility = ScriptableObject.CreateInstance<CameraUtility>();
    }
    private void OnEnable()
    {
        controls.gameInputsObj.Touch.Enable();
        controls.gameInputsObj.Touch.PrimaryContact.started += StartTouchPrimary;
        controls.gameInputsObj.Touch.PrimaryContact.canceled += EndTouchPrimary;
    }
    private void OnDisable()
    {
        controls.gameInputsObj.Touch.Enable();
    }
    private void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        positionStart = GetCtx(ctx);
        timeStart = (float)ctx.startTime;
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        positionEnd = GetCtx(ctx);
        timeEnd = (float)ctx.time;
        GetSwipeDirectionAndTime();
        sendSwipeDirection(direction, force);
    }
    private Vector3 GetCtx(InputAction.CallbackContext ctx)
    {
        var camPosition = cameraUtility.ScreenToWorld(cameraMain,
            controls.gameInputsObj.Touch.PrimaryPositition.ReadValue<Vector2>());
        return camPosition;
    }
    private void GetSwipeDirectionAndTime()
    {
        if (!(Vector3.Distance(positionStart, positionEnd) >= minimumDistance) ||
            !((timeEnd - timeStart) <= maximumTime)) return;
        var vectorDir = positionEnd - positionStart;
        direction = new Vector2(vectorDir.x, vectorDir.y);
        force = timeEnd - timeStart;
        //Debug.DrawLine(positionStart, positionEnd, Color.red, 2f);
    }
}