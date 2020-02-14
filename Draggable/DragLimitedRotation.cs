using UnityEngine;
using UnityEngine.Serialization;

namespace ArtisanDream.Experimental.Draggable
{
    public class DragLimitedRotation: DragRotationBase
    {
        [FormerlySerializedAs("MinLimit")] public float minLimit;
        [FormerlySerializedAs("MaxLimit")] public float maxLimit;
        private float rotation;

        private void OnMouseDown()
        {
    
        }

        public override void OnMouseDrag()
        {
        
        }
    }
}