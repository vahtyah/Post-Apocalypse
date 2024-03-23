using System;
using UnityEngine;

public class CharacterHealthComponent<S> : IHealable, IDamageable where S : Stats
{
    protected S stats;
    private float currentHealth;
    public Action OnDie;
    private Action<float> OnChangeHealth { get; set; }

    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            OnChangeHealth?.Invoke(currentHealth);
            if (currentHealth <= 0) OnDie?.Invoke();
        }
    }

    public float MaxHealth
    {
        get => stats.MaxHealth;
        private set => stats.MaxHealth = Mathf.Max(value, 0);
    }

    public CharacterHealthComponent(S stats)
    {
        this.stats = stats;
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float _damage) { CurrentHealth -= _damage; }

    public void Heal(float _heal) { CurrentHealth += _heal; }

    public void ResetHealth() { CurrentHealth = MaxHealth; }

    public float GetHealthAmountNormalized() => (float)CurrentHealth / MaxHealth;

    public void AddOnDieListener(Action _onDie) { OnDie += _onDie; }

    public void RemoveOnDieListener(Action _onDie) { OnDie -= _onDie; }

    public void AddOnChangeHealthListener(Action<float> _onChangeHealth) { OnChangeHealth += _onChangeHealth; }

    public void RemoveOnChangeHealthListener(Action<float> _onChangeHealth) { OnChangeHealth -= _onChangeHealth; }
}

public interface IDamageable
{
    void TakeDamage(float damage);
}

public interface IHealable
{
    void Heal(float healAmount);
}