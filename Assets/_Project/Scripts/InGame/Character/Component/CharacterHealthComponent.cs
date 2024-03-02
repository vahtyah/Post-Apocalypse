using System;
using UnityEngine;

public class CharacterHealthComponent : IHealable, IDamageable
{
    private float currentHealth;
    private float maxHealth;
    public Action OnDie { get; private set; }
    public Action<float> OnChangeHealth { get; private set; }

    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
           OnChangeHealth?.Invoke(currentHealth);
            if (currentHealth <= 0) OnDie?.Invoke();
        }
    }

    public float MaxHealth
    {
        get => maxHealth;
        private set => maxHealth = Mathf.Max(value, 0);
    }

    public CharacterHealthComponent(float _maxHealth)
    {
        MaxHealth = _maxHealth;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth -= _damage; 
    }

    public void Heal(float _heal)
    {
        CurrentHealth += _heal; 
    }
    
    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }
    
    public void AddOnDieListener(Action _onDie)
    {
        OnDie += _onDie;
    }
    
    public void RemoveOnDieListener(Action _onDie)
    {
        OnDie -= _onDie;
    }
    
    public void AddOnChangeHealthListener(Action<float> _onChangeHealth)
    {
        OnChangeHealth += _onChangeHealth;
    }
    
    public void RemoveOnChangeHealthListener(Action<float> _onChangeHealth)
    {
        OnChangeHealth -= _onChangeHealth;
    }
}


public interface IDamageable
{
    void TakeDamage(float damage);
}

public interface IHealable
{
    void Heal(float healAmount);
}