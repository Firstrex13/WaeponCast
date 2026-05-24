using System;
using UnityEngine;

public class EnemyHealth : Bar, IDamageable
{
    [SerializeField] private HealthConfig _config;
    [SerializeField] private DamageTextPopUp _damageTextPopUp;

    public event Action EnemyDied;

    public float CurentHealth => Current;

    private void OnEnable()
    {
        MaxValue = _config.Health;
        CurrentValue = MaxValue;
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
                    EnemyDied?.Invoke();
                    _damageTextPopUp.ShowDamageText(damage);
                }

                OnHit();
                _damageTextPopUp.ShowDamageText(damage);
            }
        }
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}