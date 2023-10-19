using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _currentHealth;

    private int _maxHealth = 100;    

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth > 0)
            _currentHealth -= damage;

        _healthBar.SetHealth(_currentHealth);
    }

    public void TakeHealing(int healing)
    {
        if (_currentHealth < _maxHealth)
            _currentHealth += healing;

        _healthBar.SetHealth(_currentHealth);
    }
}