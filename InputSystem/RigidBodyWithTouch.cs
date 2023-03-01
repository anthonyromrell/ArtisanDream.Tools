using UnityEngine;

[RequireComponent(typeof(TouchSwipeBehaviour))]
[RequireComponent(typeof(Rigidbody))]
public class RigidBodyWithTouch : MonoBehaviour
{
     public float force = 10f;
     private Rigidbody rb;
     private TouchSwipeBehaviour touchSwipeBehaviourObj;

     private void Awake()
     {
          rb = GetComponent<Rigidbody>();
          touchSwipeBehaviourObj = GetComponent<TouchSwipeBehaviour>();
     }
     private void OnEnable()
     {
          touchSwipeBehaviourObj.sendSwipeDirection += GetSwipeDirection;
     }

     private void GetSwipeDirection(Vector2 value, float num)
     {
          rb.AddForce(value*num*force);
     }
}