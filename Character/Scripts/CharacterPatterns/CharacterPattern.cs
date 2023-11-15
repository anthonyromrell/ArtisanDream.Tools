using UnityEngine;

public abstract class CharacterPattern : ScriptableObject
{
    [HideInInspector] public Vector3 inputs;
    protected Vector3 PositionDirection;
    public string hAxis = "Horizontal", vAxis = "Vertical";
    public float speed = 10f, gravity = 3f, jumpForce = 30f;
    public int jumpCount = 0, jumpCountMax = 2;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public abstract void Move(CharacterController controller);
}