using UnityEngine;
using UnityEngine.Events;


	public class MouseBehaviours : MonoBehaviour
	{
		public UnityEvent Event;
	
		private void OnMouseDown()
		{
			Event.Invoke();
		}
	}
