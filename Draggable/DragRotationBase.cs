using UnityEngine;

namespace ArtisanDream.Experimental
{
    public abstract class DragRotationBase : MonoBehaviour {

        public string AxisName = "Mouse X";
        public float Speed = 10.0F;

        public abstract void OnMouseDrag ();
    }
}



