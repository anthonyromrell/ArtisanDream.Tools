using UnityEngine;

public class ColorMatch : SimpleMatchID
{
    private SpriteRenderer[] spriteRenderers;
    private ColorData colorData;
    private void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        colorData = (ColorData) nameIdObj;
    }

    public void ChangeColor()
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = colorData.value;
        }
    }
}