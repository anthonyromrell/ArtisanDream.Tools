using UnityEngine;

namespace ArtisanDream.Experimental
{
	public class DragFreeRotation : DragRotationBase
	{
		private float distance;

		public override void OnMouseDrag()
		{
			distance = Input.GetAxis(axisName) * speed;
		}
	}
}