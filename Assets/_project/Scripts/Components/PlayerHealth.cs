using System;
using UnityEngine;

public class PlayerHealth : BarComponent, IDamageable
{
    [SerializeField] private float _invulnerableTime;

    private PlayerProgress _playerProgress;
    private float _timer;

    public event Action Healed;
    public event Action Died;

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Initialize(IProgressService playerProgress)
    {
        _timer = 0;
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

        if (_timer > 0)
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
            _timer = _invulnerableTime;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
                Died?.Invoke();
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
}