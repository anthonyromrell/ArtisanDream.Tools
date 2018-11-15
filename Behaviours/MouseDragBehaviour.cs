using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Behaviours
{
	public class MouseDragBehaviour : MonoBehaviour
	{
		public UnityEvent Event;

		private void OnMouseDrag()
		{
			Event.Invoke();
		}
	}
}
