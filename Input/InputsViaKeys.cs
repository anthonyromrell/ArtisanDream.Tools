using UnityEngine;

public class InputsViaKeys : MonoBehaviour
{
    public GameAction arrowKeyAction, horizontalAction, jumpAction; public GameAction endGameAction;

    private void Start()
    {
        endGameAction.raiseNoArgs += DisableScript;
    }

    private void DisableScript()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) arrowKeyAction.raise?.Invoke(180);
        if (Input.GetKey(KeyCode.RightArrow)) arrowKeyAction.raise?.Invoke(0);
        horizontalAction.raise?.Invoke(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump")) jumpAction.raiseNoArgs?.Invoke();
    }
}