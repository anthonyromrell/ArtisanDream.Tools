using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "Character/MovePattern Dual")]
	public class MovePatternDual : MovePattern
	{
		[FormerlySerializedAs("Count")] public IntData count;
		private int canJump;
		//public bool doubleJump = true;
	
		public override void Call(CharacterController controller, Transform transform)
		{
			if (controller.isGrounded)
			{
				Move(transform);
				count.Value = 2;
			}
		
			if (Input.GetButtonDown("Jump") && count.Value > 0)
			{
				MoveDirection.y = 4;
				count.Value--;
			}
		
			//	moveDirection.y += MoveY.Value;
		
			Move(controller);
		}
	}

