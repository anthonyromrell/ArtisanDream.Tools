using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/ColorData")]
	public class ColorData : ScriptableObject {

		[FormerlySerializedAs("Value")] public Color value = Color.blue;
	}