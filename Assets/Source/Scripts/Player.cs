using System;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] private int _damage;
    [SerializeField] private int _healing;

    [SerializeField]private int _maxHealth = 100;
    private int _currentHealth;

    public event Action<int> MaxHealthEstablished;
    public event Action<int> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        MaxHealthEstablished?.Invoke(_maxHealth);
    }

    public void TakeDamage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= _damage, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeHealing()
    {
        _currentHealth = Mathf.Clamp(_currentHealth += _healing, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}