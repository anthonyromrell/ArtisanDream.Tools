using UnityEngine;

//Made By Anthony Romrell
namespace ArtisanDream.Tools.Objects
{
	[CreateAssetMenu]
	public class FloatData : ScriptableObject
	{
		public float value;
	
		public virtual float Value
		{
			get { return value;}
			set { this.value = value; }
		}
	}
}