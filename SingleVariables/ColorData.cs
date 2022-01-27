using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Single Variables/ColorData")]
public class ColorData : NameID
{
	public Color value = Color.blue;

	public void ChangeColor(SpriteRenderer spriteRenderer)
	{
		spriteRenderer.color = value;
	}
	
	public void ChangeColor(Material material)
	{
		material.color = value;
	}
	
	public void ChangeColor(Image image)
	{
		image.color = value;
	}
}