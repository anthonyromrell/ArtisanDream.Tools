using UnityEngine;


	[CreateAssetMenu(menuName = "Character/MovePattern Dual")]
	public class MovePatternDual : MovePattern
	{
		public IntData Count;
		private int canJump;
		//public bool doubleJump = true;
	
		public override void Call(CharacterController controller, Transform transform)
		{
			if (controller.isGrounded)
			{
				Move(transform);
				Count.Value = 2;
			}
		
			if (Input.GetButtonDown("Jump") && Count.Value > 0)
			{
				MoveDirection.y = 4;
				Count.Value--;
			}
		
			//	moveDirection.y += MoveY.Value;
		
			Move(controller);
		}
	}

