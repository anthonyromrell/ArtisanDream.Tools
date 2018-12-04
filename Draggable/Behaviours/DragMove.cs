using ArtisanDream.Tools.Draggable.Interfaces;
using UnityEngine;

namespace ArtisanDream.Tools.Draggable.Behaviours
{
	public class DragMove : MonoBehaviour, IDrag{


	

		public void OnMouseDown()
		{
		
		}

		public void OnMouseDrag()
		{
		
			transform.Translate(Vector3.right*Input.GetAxis("Mouse X"));
		}
	}
}
