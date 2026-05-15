using System;
using UnityEngine;

public class PlayerHealth : Bar, IDamageable
{
    [SerializeField] private PlayerHealthView _playerHealthView;

    private PlayerProgress _playerProgress;

    public event Action Healed;
    public event Action Died;

    private void Start()
    {
        MaxValue = _playerProgress.Stats.Health;
        CurrentValue = MaxValue;
    }

    public void Initialize(IProgressService playerProgress)
    {
        _playerProgress = playerProgress.GetProgress();
        _playerHealthView.Initialize();
    }

    public void TakeDamage(int damage)
    {
        if (CurrentValue > 0)
        {
            if (damage < 0)
            {
                damage = 0;
            }

            if (damage > 0)
            {
                CurrentValue -= damage;

                if (CurrentValue <= 0)
                {
                    CurrentValue = 0;
                    Died?.Invoke();
                }

                OnHit();
            }
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