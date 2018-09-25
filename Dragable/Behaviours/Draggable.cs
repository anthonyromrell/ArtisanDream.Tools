using UnityEngine;

//Made By Anthony Romrell
public class Draggable : MonoBehaviour, IDrag
{
    private Vector3 offsetPosition;
    private Vector3 newPostion;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void OnMouseDown()
    {
        offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDrag()
    {
        newPostion = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
        transform.position = newPostion;
    }
}