using UnityEngine;

	[CreateAssetMenu(menuName = "Utilities/Instance Object")]
	//Made By Anthony Romrell
	public class Instancer : ScriptableObject
	{
		public void CreateInstance(GameObject instance)
		{
			Instantiate(instance);
		}
	}
