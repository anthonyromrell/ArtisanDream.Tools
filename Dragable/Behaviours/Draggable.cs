using System.Collections;
using UnityEngine;

//Made By Anthony Romrell
public class Draggable : MonoBehaviour
{
    private Vector3 offsetPosition;
    private Vector3 newPostion;
    private Camera cam;

    public bool CanDrag;

    private void Start()
    {
        cam = Camera.main;
    }

    public IEnumerator OnMouseDown()
    {
        offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForFixedUpdate();
        CanDrag = true;
        while (CanDrag)
        {
            yield return new WaitForFixedUpdate();
            newPostion = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
            transform.position = newPostion;
        }
    }

    private void OnMouseUp()
    {
        CanDrag = false;
    }

//    public void OnMouseDrag()
//    {
//        newPostion = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
//        transform.position = newPostion;
//    }
}