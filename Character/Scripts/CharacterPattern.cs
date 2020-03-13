using UnityEngine;

public abstract class CharacterPattern : ScriptableObject
{
    protected Vector3 positionDirection;
    public string hAxis = "Horizontal", vAxis = "Vertical";
    public float speed = 10f, gravity = 3f, jumpForce = 30f;
    public int jumpCount = 0, jumpCountMax = 2;
   
    public abstract void Call(CharacterController controller);
}