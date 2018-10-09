using UnityEngine;

//Made By Anthony Romrell
namespace ArtisanDream.Experimental
{
	[RequireComponent(typeof(CharacterController))]

	public class CharacterMovement : MonoBehaviour 
	{
	
		private CharacterController controller;
		public MovePattern Pattern;

		private void Start()
		{
			controller = GetComponent<CharacterController>();
		}

		void Update() {
			Pattern.Invoke(controller, transform);
		}
	}
}