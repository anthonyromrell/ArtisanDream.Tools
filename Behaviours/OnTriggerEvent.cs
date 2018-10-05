using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Behaviours
{
	public class OnTriggerEvent : MonoBehaviour
	{

		public UnityEvent Event;
	
		private void OnTriggerEnter(Collider other)
		{
			Event.Invoke();
		}
	}
}
