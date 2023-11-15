using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Collections/Weapon Collectible")]
public class WeaponCollectible : Collectible
{
    public UnityEvent useEvent;
    
    public override void Use()
    {
        useEvent.Invoke();
    }

    public void Attack ()
    {
        Debug.Log("Attack " + this);
    }

    public void Equip()
    {
        
    }

    public void Upgrade()
    {
        
    }
    
}