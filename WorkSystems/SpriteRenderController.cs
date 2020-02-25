using UnityEngine;

[CreateAssetMenu]
public class SpriteRenderController : ScriptableObject
{
    [HideInInspector]
    public SpriteRenderer spriteRendererObj;

    public void StoreSpriteRender(SpriteRenderer spriteRenderer)
    {
        spriteRendererObj = spriteRenderer;
    }
}