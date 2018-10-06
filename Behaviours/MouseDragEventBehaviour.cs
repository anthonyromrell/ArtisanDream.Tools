using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Behaviours
{
	public class MouseDragEventBehaviour : MonoBehaviour
	{
		public UnityEvent Event;

		private void OnMouseDrag()
		{
			Event.Invoke();
		}
	}
}
