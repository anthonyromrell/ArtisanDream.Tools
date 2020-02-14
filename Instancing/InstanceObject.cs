using UnityEngine;

	[CreateAssetMenu(menuName = "Instancing/Instance Object")]
	//Made By Anthony Romrell
	public class InstanceObject : ScriptableObject
	{
		public void CreateInstance(GameObject instance)
		{
			Instantiate(instance);
		}
	}
