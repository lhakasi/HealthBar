using UnityEngine;

public class DamageButton : MonoBehaviour
{
    private Player _player;
    
    private int _damage = 10;

    public void DealDamage() =>
        _player.TakeDamage(_damage);    
}