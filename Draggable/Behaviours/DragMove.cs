using ArtisanDream.Tools.Dragable.Interfaces;
using UnityEngine;

namespace ArtisanDream.Tools.Dragable.Behaviours
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
