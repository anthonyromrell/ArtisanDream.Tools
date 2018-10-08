using UnityEngine;

//Made By Anthony Romrell
namespace ArtisanDream.Tools
{
	[CreateAssetMenu]
	public class FloatData : ScriptableObject
	{
		[SerializeField]
		protected float value;
	
		public virtual float Value
		{
			get => value;
			set => this.value = value;
		}
	}
}