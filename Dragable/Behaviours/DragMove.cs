using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour, IDrag{


	

	public void OnMouseDown()
	{
		
	}

	public void OnMouseDrag()
	{
		
		transform.Translate(Vector3.right*Input.GetAxis("Mouse X"));
	}
}
