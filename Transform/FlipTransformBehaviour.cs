using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{
    public KeyCode key1 = KeyCode.RightArrow, key2 = KeyCode.LeftArrow;
    public float direction1 = 0, direction2 = 180;
    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            transform.rotation = Quaternion.Euler(0,direction1,0);
        }

        if (!Input.GetKeyDown(key2)) return;
        transform.rotation = Quaternion.Euler(0,direction2,0);
    }
}