using System;
using UnityEngine;
using HealthImpact;

[RequireComponent(typeof(Health))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _healing;

    private Health _health;

    private int MaxHealth => _health.MaxHealth;
    private int CurrentHealth => _health.CurrentHealth;
        
    public event Action HealthChanged;

    private void Awake() => _health = GetComponent<Health>();   

    public void ChangeHealth(ImpactTypes impactType)
    {
        switch (impactType)
        {
            case ImpactTypes.Healing:
                TakeHealing(CurrentHealth);
                break;

            case ImpactTypes.Damage:
                TakeDamage(CurrentHealth);
                break;
        }

        HealthChanged?.Invoke();
    }

    public void PressDamageButton() => ChangeHealth(ImpactTypes.Damage);    

    public void PressHealingButton() => ChangeHealth(ImpactTypes.Healing);    

    private void TakeDamage(int currentHealth) =>    
        _health.SetCurrentHealth(Mathf.Clamp(currentHealth -= _damage, 0, MaxHealth));
    
    private void TakeHealing(int currentHealth) =>    
        _health.SetCurrentHealth(Mathf.Clamp(currentHealth += _healing, 0, MaxHealth));
}

namespace HealthImpact
{
    public enum ImpactTypes
    {
        Damage,
        Healing
    }
}
