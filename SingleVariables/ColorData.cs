using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/ColorData")]
public class ColorData : NameId
{
	public Color value = Color.blue;

	public void ChangeSpriteRenderColor(SpriteRenderer spriteRendererOjb)
	{
		spriteRendererOjb.color = value;
	}
	
	public void ChangeSpriteRenderColor(SpriteRenderController spriteRendererController)
	{
		spriteRendererController.spriteRendererObj.color = value;
	}
}