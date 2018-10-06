using UnityEngine;

namespace ArtisanDream.Tools.Functions
{
	public abstract class FunctionBase : ScriptableObject
	{
		public abstract void Run(object Data);
	}
}