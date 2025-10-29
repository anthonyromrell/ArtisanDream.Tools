using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Simple IntData")]
public class SimpleIntData : MonoBehaviour
{
    public int value;
    
    public void UpdateValue(int amount)
    {
        value += amount;
    }
    
    //SetData ()
    public void SetValue(int amount)
    {
        value = amount;
    }
}
