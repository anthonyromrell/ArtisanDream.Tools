using UnityEngine;
using UnityEngine.Serialization;

namespace ArtisanDream.Experimental
{
    public abstract class DragRotationBase : MonoBehaviour {

        [FormerlySerializedAs("AxisName")] public string axisName = "Mouse X";
        [FormerlySerializedAs("Speed")] public float speed = 10.0F;

        public abstract void OnMouseDrag ();
    }
}



