using UnityEngine;
using UnityEngine.Serialization;

//Made By Anthony Romrell
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    [FormerlySerializedAs("Pattern")] public MovePattern pattern;

    public void SetPattern(MovePattern pattern)
    {
        this.pattern = pattern;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        pattern.Call(controller, transform);
    }
}