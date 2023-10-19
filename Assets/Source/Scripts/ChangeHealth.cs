using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _damage = 10;
    private int _healing = 10;

    public void DealDamage() =>
        _player.TakeDamage(_damage);

    public void HealPlayer() =>
        _player.TakeHealing(_healing);
}