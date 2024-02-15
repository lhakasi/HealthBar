using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.MaxHealthEstablished += OnMaxHealthEstablished;
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.MaxHealthEstablished -= OnMaxHealthEstablished;
        _player.HealthChanged -= OnHealthChanged;
    }

    protected abstract void OnMaxHealthEstablished(int health);

    protected abstract void OnHealthChanged(int health);
}
