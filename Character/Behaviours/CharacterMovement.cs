using UnityEngine;

//Made By Anthony Romrell
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    public MovePattern Pattern;

    public void SetPattern(MovePattern pattern)
    {
        Pattern = pattern;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Pattern.Call(controller, transform);
    }
}