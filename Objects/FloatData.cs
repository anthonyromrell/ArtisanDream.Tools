using UnityEngine;

//Made By Anthony Romrell
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