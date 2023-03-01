using UnityEngine;

[CreateAssetMenu]
public class CameraUtility : ScriptableObject
{
   public Vector3 ScreenToWorld(Camera camera, Vector3 position)
   {
      position.z = camera.nearClipPlane;
      return camera.ScreenToWorldPoint(position);
   }
}
