using UnityEngine;
using UnityEngine.Serialization;

//Made By Anthony Romrell
	[CreateAssetMenu(menuName = "Character/MovePattern")]
	public class MovePattern : ScriptableObject 
	{
		[FormerlySerializedAs("Gravity")] public FloatData gravity;

		[FormerlySerializedAs("MoveX")] public FloatData moveX;
		[FormerlySerializedAs("MoveY")] public FloatData moveY;
		[FormerlySerializedAs("MoveZ")] public FloatData moveZ;
		[FormerlySerializedAs("RotX")] public FloatData rotX;
		[FormerlySerializedAs("RotY")] public FloatData rotY;
		[FormerlySerializedAs("RotZ")] public FloatData rotZ;

		protected Vector3 MoveDirection;
		private Vector3 rotDirection;

		private void OnEnable()
		{
			MoveDirection = Vector3.zero;
			rotDirection = Vector3.zero;
		}

		public virtual void Call(CharacterController controller, Transform transform)
		{
			
			
			if (controller.isGrounded)
			{
				Move(transform);
			}

			Move(controller);
		}
		
		protected void Move(Transform transform)
		{
			MoveDirection.Set(moveX.value, moveY.value, moveZ.value);
			rotDirection.Set(rotX.value, rotY.value, rotZ.value);
			transform.Rotate(rotDirection);
			MoveDirection = transform.TransformDirection(MoveDirection);
		}

		protected void Move(CharacterController controller)
		{
			MoveDirection.y = gravity.value;
			controller.Move(MoveDirection * Time.deltaTime);
		}
	}

