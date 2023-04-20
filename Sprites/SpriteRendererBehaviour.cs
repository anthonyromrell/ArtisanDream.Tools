using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererBehaviour : MonoBehaviour
{
    private SpriteRenderer spriteRendererObj;
    public UnityEvent startEvent;
    
    void Start()
    {
        spriteRendererObj = GetComponent<SpriteRenderer>();
        startEvent.Invoke();
    }

    public void ChangeSpriteColor(ColorData colorDataObj)
    {
        spriteRendererObj.color = colorDataObj.value;
    }

    public void MatchCameraSize(Camera cam)
    {
        var dimensions = cam.rect;
        spriteRendererObj.size = dimensions.size;
    }
}