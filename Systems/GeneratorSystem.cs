using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "System/Generator")]
public class GeneratorSystem : ScriptableObject
{
    public Vector3DataSystem vector3DataSystem;
    public GameObject prefab;

    public void Generate()
    {
        Instantiate(prefab, vector3DataSystem.ReturnRandomVector3(), Quaternion.identity);
    }
}
