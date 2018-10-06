using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Behaviours
{
	public class MouseDownBehaviour : MonoBehaviour
	{
		public UnityEvent Event;
	
		private void OnMouseDown()
		{
			Event.Invoke();
		}
	}
}