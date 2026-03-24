using System;
using UnityEngine;

public class EnemyHealth : Bar, IDamageable
{
    [SerializeField] private HealthConfig _config;

    public event Action Died;

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
                    Died?.Invoke();
                }

               OnHit();
            }
        }
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}
