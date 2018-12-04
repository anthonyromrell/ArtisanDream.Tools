
namespace ArtisanDream.Experimental
{
	public class DragRotClick : DragRotationBase
	{
		private bool canRot;
	
		public override void OnMouseDrag()
		{
			canRot = true;
		}
	}
}