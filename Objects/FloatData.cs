using UnityEngine;

//Made By Anthony Romrell

	[CreateAssetMenu]
	public class FloatData : ScriptableObject
	{
		[SerializeField] protected float value;
		
		public virtual float Value
		{
			get => this.value;
			set => this.value = value;
		}
	}
