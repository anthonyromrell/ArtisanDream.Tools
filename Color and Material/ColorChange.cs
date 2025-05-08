using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color newColor = Color.red;

    void OnCollisionEnter(Collision collision)
    {
        // Change the object's color upon collision with another GameObject
        GetComponent<Renderer>().material.color = newColor;
    }
}