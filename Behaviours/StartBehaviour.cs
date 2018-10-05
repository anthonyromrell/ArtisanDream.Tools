using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Behaviours
{
	public class StartBehaviour : MonoBehaviour
	{
		public UnityEvent Event;

		void Start () {
			Event.Invoke();
		}
	}
}
