using UnityEngine;
using UnityEngine.Events;

public class MouseDownBehaviour : MonoBehaviour
{
	public UnityEvent Event;
	
	private void OnMouseDown()
	{
		Event.Invoke();
	}
}