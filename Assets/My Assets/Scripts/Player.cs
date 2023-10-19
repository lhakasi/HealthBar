using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private DamageButton _damageButton;
    [SerializeField] private HealingButton _healingButton;

    private int _maxHealth = 100;
    private int _currentHealth;

    private Button _healingButtonComponent;
    private Button _damageButtonComponent;

    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);

        _damageButtonComponent = _damageButton.GetComponent<Button>();
        _healingButtonComponent = _healingButton.GetComponent<Button>();

        _damageButtonComponent.onClick.AddListener(TakeDamage);
        _healingButtonComponent.onClick.AddListener(TakeHealing);
    }

    private void TakeDamage()
    {
        if (_currentHealth > 0)
            _currentHealth = _damageButton.DealDamage(_currentHealth);

        _healthBar.SetHealth(_currentHealth);
    }

    private void TakeHealing()
    {
        if (_currentHealth < _maxHealth)
            _currentHealth = _healingButton.HealPlayer(_currentHealth);

        _healthBar.SetHealth(_currentHealth);
    }
}