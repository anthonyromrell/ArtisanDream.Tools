using UnityEngine;
using UnityEngine.Events;

public class MaterialMatch : SimpleMatchID
{
    private Renderer[] renderers;
    private MaterialData materialData;

    protected override void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        materialData = (MaterialData)nameIdObj;
        base.Start();
    }

    public void ChangeMaterial()
    {
        foreach (var mat in renderers)
        {
            mat.material = materialData.Value;
        }
    }
}