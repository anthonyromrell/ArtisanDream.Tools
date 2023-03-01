using UnityEngine;
public class InputPlayer : MonoBehaviour
{
    public GameInputsSO controls;
    private Vector2 move, movement;
    public FloatData speed;
    private void Awake()
    {
        controls.gameInputsObj.KeyActionMap.Vertical.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.gameInputsObj.KeyActionMap.Vertical.canceled += ctx => move = Vector2.zero;
    }
 
    private void OnEnable()
    {
        controls.gameInputsObj.KeyActionMap.Enable();
    }
    private void OnDisable()
    {
        controls.gameInputsObj.KeyActionMap.Disable();
    }
    
    private void FixedUpdate()
    {
        movement.Set(move.x, move.y);
        movement *= speed.value * UnityEngine.Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}