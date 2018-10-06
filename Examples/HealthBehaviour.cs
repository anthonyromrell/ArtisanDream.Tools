using ArtisanDream.Tools.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace ArtisanDream.Tools.Examples
{
	public class HealthBehaviour : MonoBehaviour
	{
		public FloatBase HealthLevel;
		private Image HealthImage;
	
		// Use this for initialization
		void Start ()
		{
			HealthImage = GetComponent<Image>();
		}
	
		// Update is called once per frame
		void Update ()
		{
			HealthImage.fillAmount = HealthLevel.Value;
		}
	}
}