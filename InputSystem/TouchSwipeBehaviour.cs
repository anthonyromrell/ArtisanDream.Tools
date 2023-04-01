using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-5)]
public class TouchSwipeBehaviour : MonoBehaviour
{
    public UnityAction<TouchData> sendTouchData;
    public GameInputsSO controls;
    public float minimumDistance = .2f, maximumTime = 1f;
    private TouchData touchData;
    private Camera cameraMain;
    private CameraUtility cameraUtility;
    
    private void Awake()
    {
        touchData = ScriptableObject.CreateInstance<TouchData>();
        cameraMain = Camera.main;
        cameraUtility = ScriptableObject.CreateInstance<CameraUtility>();
        controls.gameInputsObj.Touch.PrimaryContact.started += StartTouchPrimary;
        controls.gameInputsObj.Touch.PrimaryContact.canceled += EndTouchPrimary;
    }
    private void OnEnable()
    {
        controls.gameInputsObj.Touch.Enable();
    }
    private void OnDisable()
    {
        controls.gameInputsObj.Touch.Enable();
    }
    private void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        touchData.positionStart = GetCtx(ctx);
        touchData.timeStart = (float)ctx.startTime;
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        touchData.positionEnd = GetCtx(ctx);
        touchData.timeEnd = (float)ctx.time;
        GetSwipeDirectionAndTime();
        sendTouchData(touchData);
    }
    private Vector3 GetCtx(InputAction.CallbackContext ctx)
    {
        var camPosition = cameraUtility.ScreenToWorld(cameraMain,
            controls.gameInputsObj.Touch.PrimaryPositition.ReadValue<Vector2>());
        return camPosition;
    }
    private void GetSwipeDirectionAndTime()
    {
        if (!(Vector3.Distance(touchData.positionStart, touchData.positionEnd) >= minimumDistance) ||
            !((touchData.timeEnd - touchData.timeStart) <= maximumTime)) return;
        var vectorDir = touchData.positionEnd - touchData.positionStart;
        touchData.direction = new Vector2(vectorDir.x, vectorDir.y);
        touchData.force = touchData.timeEnd - touchData.timeStart;
    }
}