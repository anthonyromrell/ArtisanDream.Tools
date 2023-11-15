using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Float Object")]
public class FloatObject : ScriptableObject
{
    public float value;
}

[CreateAssetMenu(menuName = "ScriptableObjects/String Object")]
public class StringObject : ScriptableObject
{
    public string value;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Int Object")]
public class IntObject : ScriptableObject
{
    public int value;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Vector3 Object")]
public class Vector3Object : ScriptableObject
{
    public Vector3 value;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Game Objects Lists")]
public class GameObjectsLists : ScriptableObject
{
    public List<GameObject> objects;
}