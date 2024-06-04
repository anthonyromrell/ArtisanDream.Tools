using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBehaviour : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public ColorData colorData;

    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSpriteColor();
    }

    public void ChangeSprite(Sprite newSprite)
    {
        if (newSprite != null) spriteRenderer.sprite = newSprite;
    }

    public void ChangeSpriteColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

    public void ChangeSpriteSortingOrder(int newOrder)
    {
        spriteRenderer.sortingOrder = newOrder;
    }

    public void ChangeSpriteFlipX(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    public void ChangeSpriteFlipY(bool flipY)
    {
        spriteRenderer.flipY = flipY;
    }

    public void ChangeSpriteSize(Vector2 newSize)
    {
        spriteRenderer.size = newSize;
    }

    public void ChangeSpriteMaterial(Material newMaterial)
    {
        if (newMaterial != null) spriteRenderer.material = newMaterial;
    }

    public void ChangeSpriteMaterialColor(Color newColor)
    {
        spriteRenderer.material.color = newColor;
    }

    public void ChangeSpriteMaterialMainTexture(Texture newTexture)
    {
        if (newTexture != null) spriteRenderer.material.mainTexture = newTexture;
    }
    
    public void ChangeSpriteColor(ColorData colorData)
    {
        if (colorData != null)
            spriteRenderer.color = colorData.Value;
    }

    public void ChangeSpriteColor()
    {
        if (colorData != null)
            spriteRenderer.color = colorData.Value;
    }
    
}