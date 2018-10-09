using UnityEngine;

namespace ArtisanDream.Experimental
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMover : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 position, rotation;
        public float Speed = 3.0f, JumpSpeed = 4.0f, Gravity = 9.81f;
        public FloatData X, Y, Z, Rx, Ry, Rz;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                rotation.Set(Rx.Value, Ry.Value, Rz.Value);
                transform.Rotate(rotation);
                position.Set(X.Value, Y.Value, Z.Value);
                position = transform.TransformDirection(position);

                if (Input.GetButton("Jump"))
                {
                    position.y = JumpSpeed;
                }
            }

            position.y -= Gravity * Time.deltaTime;
        
            controller.Move(position * Time.deltaTime);
        }
    }
}