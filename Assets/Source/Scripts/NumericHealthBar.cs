using TMPro;
using UnityEngine;

public class NumericHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthBar;

    private string _maxHealth;
    private string _currentHealth;

    private void OnEnable()
    {
        _player.MaxHealthEstablished += OnMaxHealthEstablished;
        _player.HealthChanged += OnHealthChanged;
    }

    private void Start() => RenderHealthBar();

    private void OnDisable()
    {
        _player.MaxHealthEstablished -= OnMaxHealthEstablished;
        _player.HealthChanged -= OnHealthChanged;
    }

    public void OnMaxHealthEstablished(int health)
    {
        _maxHealth = health.ToString();
        _currentHealth = health.ToString();
    }

    public void OnHealthChanged(int health)
    {
        _currentHealth = health.ToString();

        RenderHealthBar();
    }

    private void RenderHealthBar() => _healthBar.text = $"{_currentHealth}/{_maxHealth} HP";
}