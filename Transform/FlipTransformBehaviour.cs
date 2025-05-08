using UnityEngine;

/// <summary>
/// The FlipTransformBehaviour class is responsible for flipping the orientation of a GameObject.
/// It listens for two specific key presses to determine the direction of the flip.
/// </summary>
[Tooltip("Controls the flipping of the orientation of a GameObject based on user key presses.")]
public class FlipTransformBehaviour : MonoBehaviour
{
    [Tooltip("The key to press to rotate in one direction. Default key is the Right Arrow.")]
    public KeyCode key1 = KeyCode.RightArrow;

    [Tooltip("The key to press to rotate in the other direction. Default key is the Left Arrow.")]
    public KeyCode key2 = KeyCode.LeftArrow;

    [Tooltip("The rotation in degrees to apply when the first key is pressed.")]
    public float direction1 = 0;

    [Tooltip("The rotation in degrees to apply when the second key is pressed.")]
    public float direction2 = 180;

    /// <summary>
    /// Flip the GameObject rotation based on key input, every frame.
    /// </summary>
    private void Update()
    {
        // If the first key is pressed -> rotate the GameObject to direction1
        if (Input.GetKeyDown(key1))
        {
            transform.rotation = Quaternion.Euler(0, direction1, 0);
        }

        // If the second key is NOT pressed -> do nothing
        if (!Input.GetKeyDown(key2)) return;

        // If the second key is pressed -> rotate the GameObject to direction2
        transform.rotation = Quaternion.Euler(0, direction2, 0);
    }
}