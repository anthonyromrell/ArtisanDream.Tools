using UnityEngine;

[CreateAssetMenu(fileName = "AiBrain", menuName = "Ai/Brain")]
public class AiBrain : ScriptableObject
{
	public AiBase Base;

	public void ChangeBase(AiBase b)
	{
		Base = b;
	}
}