using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{
    public KeyCode key1 = KeyCode.LeftArrow, key2 = KeyCode.RightArrow;
    public float direction1 = 0, direction2 = 180;
    void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            transform.rotation = Quaternion.Euler(0,direction1,0);
        }

        if (Input.GetKeyDown(key2))
        {
            transform.rotation = Quaternion.Euler(0,direction2,0);
        }
    }

    public void FlipRotate (float value)
    {
        transform.Rotate(0,value,0);
    }
}