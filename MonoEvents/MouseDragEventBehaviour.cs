using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseDragEventBehaviour : MonoBehaviour
{
	public UnityEvent Event;

	private void OnMouseDrag()
	{
		Event.Invoke();
	}
}
