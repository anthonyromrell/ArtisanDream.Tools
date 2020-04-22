using UnityEngine;

public class InputsViaKeys : MonoBehaviour
{
    public GameAction speed;
    public GameAction jump;
    public GameAction direction;
    public GameAction endGame;

    private void Start()
    {
        endGame.raiseNoArgs += DisableScript;
    }

    private void DisableScript()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) direction.raise?.Invoke(180);
        if (Input.GetKey(KeyCode.RightArrow)) direction.raise?.Invoke(0);
        speed.raise?.Invoke(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump")) jump.raiseNoArgs?.Invoke();
    }
}