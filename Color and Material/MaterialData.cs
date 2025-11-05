using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/MaterialData")]
public class MaterialData : NameId
{
    [SerializeField] private Material value;
    public UnityEvent onValueChanged;

    public Material Value
    {
        get => value;
        private set
        {
            this.value = value;
            onValueChanged?.Invoke();
        }
    }

    public void ChangeMaterial(Object component)
    {
        if (component is Renderer renderer)
        {
            renderer.material = Value;
        }
    }

    public void ChangeMaterial(Material material)
    {
        Value = material;
    }
}