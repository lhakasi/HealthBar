using TMPro;
using UnityEngine;

public class NumericHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _healthBar;

    private string _maxHealth;
    private string _currentHealth;

    private void Start() => RenderHealthBar();

    protected override void OnMaxHealthEstablished(int health)
    {
        _maxHealth = health.ToString();
        _currentHealth = health.ToString();
    }

    protected override void OnHealthChanged(int health)
    {
        _currentHealth = health.ToString();

        RenderHealthBar();
    }

    private void RenderHealthBar() => _healthBar.text = $"{_currentHealth}/{_maxHealth} HP";
}