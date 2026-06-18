using System;
using UnityEngine;

public class PlayerHealth : BarComponent, IDamageable
{
    private PlayerProgress _playerProgress;

    public event Action Healed;

    private void Update()
    {
        Timer -= Time.deltaTime;
    }

    public void Initialize(IProgressService playerProgress)
    {
        Timer = 0;
        _playerProgress = playerProgress.GetProgress();
        MaxValue = _playerProgress.Stats.Health;
        CurrentValue = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        if (CurrentValue < 0)
        {
            return;
        }

        if (Timer > 0)
        {
            return;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        if (damage > 0)
        {
            CurrentValue -= damage;
            Timer = InvulnerableTime;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
                OnDied();
            }

            OnHit();
        }
    }

    public void ApplyHeal(int healAmount)
    {
        if (healAmount < 0)
        {
            healAmount = 0;
        }

        if (healAmount > 0)
        {
            CurrentValue += healAmount;

            if (CurrentValue >= MaxValue)
            {
                CurrentValue = MaxValue;
            }

            Healed?.Invoke();
        }
    }

    public override void OnHit()
    {
        base.OnHit();
    }

    public override void OnDied()
    {
        base.OnDied();
    }
}