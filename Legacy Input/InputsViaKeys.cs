using UnityEngine;

public class InputsViaKeys : MonoBehaviour
{
    public GameActionAdvanced arrowKeyAction, horizontalAction, jumpAction; public GameAction endGameAction;

    private void Start()
    {
        endGameAction.RaiseNoArgs += DisableScript;
    }

    private void DisableScript()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) arrowKeyAction.Raise?.Invoke(180);
        if (Input.GetKey(KeyCode.RightArrow)) arrowKeyAction.Raise?.Invoke(0);
        horizontalAction.Raise?.Invoke(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump")) jumpAction.RaiseNoArgs?.Invoke();
    }
}