using UnityEngine;


[CreateAssetMenu]
public class Collectable : ScriptableObject
{
    public Sprite art;
    public string description;
    public GameObject gameObject;
    public int price = 10;
    public bool collected;
    
    public void Collect()
    {
        collected = true;
    }
    
    
    
}