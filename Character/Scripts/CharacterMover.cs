using UnityEngine;
using UnityEngine.Serialization;

namespace ArtisanDream.Experimental
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMover : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 position, rotation;
        [FormerlySerializedAs("Speed")] public float speed = 3.0f;
        [FormerlySerializedAs("JumpSpeed")] public float jumpSpeed = 4.0f;
        [FormerlySerializedAs("Gravity")] public float gravity = 9.81f;
        [FormerlySerializedAs("X")] public FloatData x;
        [FormerlySerializedAs("Y")] public FloatData y;
        [FormerlySerializedAs("Z")] public FloatData z;
        [FormerlySerializedAs("Rx")] public FloatData rx;
        [FormerlySerializedAs("Ry")] public FloatData ry;
        [FormerlySerializedAs("Rz")] public FloatData rz;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                rotation.Set(rx.value, ry.value, rz.value);
                transform.Rotate(rotation);
                position.Set(x.value, y.value, z.value);
                position = transform.TransformDirection(position);

                if (Input.GetButton("Jump"))
                {
                    position.y = jumpSpeed;
                }
            }

            position.y -= gravity * Time.deltaTime;
        
            controller.Move(position * Time.deltaTime);
        }
    }
}