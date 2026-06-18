using UnityEngine;

public class EnemyHealth : BarComponent, IDamageable
{
    [SerializeField] private HealthConfig _config;
    [SerializeField] private DamageTextPopUp _damageTextPopUp;

    public float CurentHealth => Current;

    private void OnEnable()
    {
        MaxValue = _config.Health;
        CurrentValue = MaxValue;
        Timer = 0;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
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
                _damageTextPopUp.ShowDamageText(damage);
            }

            OnHit();
            _damageTextPopUp.ShowDamageText(damage);
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