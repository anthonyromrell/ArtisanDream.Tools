using UnityEngine;

[RequireComponent(typeof(TouchSwipeBehaviour))]
[RequireComponent(typeof(Rigidbody))]
public class RigidBodyWithTouch : MonoBehaviour
{
     public float force = 10f;
     private Rigidbody rb;
     private TouchSwipeBehaviour touchSwipeBehaviourObj;
     
     private void OnEnable()
     {
          rb = GetComponent<Rigidbody>();
          touchSwipeBehaviourObj = GetComponent<TouchSwipeBehaviour>();
          touchSwipeBehaviourObj.sendTouchData += GetSwipeDirection;
     }

     private void GetSwipeDirection(FromTouchData data)
     {
          rb.AddForce(data.direction*force);
     }
}