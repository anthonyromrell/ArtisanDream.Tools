using ArtisanDream.Tools.Objects;
using UnityEngine;

namespace ArtisanDream.Tools.Examples
{
	public class PlayerTrigger : MonoBehaviour
	{
		public FloatBase HealthLevel;
		public FloatBase EvilPower;
	
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void OnTriggerEnter ()
		{
			HealthLevel.Value -= EvilPower.Value;
		}
	}
}
