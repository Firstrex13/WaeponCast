using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthConfig _playerConfig;
    [SerializeField] private float _currentValue;

    private int _maxValue;

    public event Action Hit;
    public event Action Healed;
    public event Action Died;

    public float CurrentHealth => _currentValue;
    public int MaxValue => _maxValue;

    public void Awake()
    {
        _maxValue = _playerConfig.Health;
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (_currentValue > 0)
        {
            if (damage < 0)
            {
                damage = 0;
            }

            if (damage > 0)
            {
                _currentValue -= damage;

                if (_currentValue <= 0)
                {
                    _currentValue = 0;
                    Died?.Invoke();
                }

                Hit?.Invoke();
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
            _currentValue += healAmount;

            if (_currentValue >= _maxValue)
            {
                _currentValue = _maxValue;
            }

            Healed?.Invoke();
        }
    }
}
