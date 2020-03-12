using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 positionDirection;
    public string hAxis = "Horizontal";
    public string vAxis = "Vertical";
    public float speed = 10f;
    public float gravity = 3f;
    public float jumpForce = 30f;
    protected int jumpCount = 0;
    public int jumpCountMax = 2;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
}