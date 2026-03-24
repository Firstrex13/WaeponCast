using System;

public class PlayerHealth : Bar, IDamageable
{
    public event Action Healed;
    public event Action Died;

    private void OnEnable()
    {
        MaxValue = PlayerData.Stats.Health;
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