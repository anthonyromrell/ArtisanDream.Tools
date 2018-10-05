using UnityEngine;

namespace ArtisanDream.Tools.Functions
{
	[CreateAssetMenu(fileName = "DebugObject")]
	public class DebugObject : ScriptableObject 
	{

		public void Raise(string s)
		{
			Debug.Log(s);
		}
	
	}
}
