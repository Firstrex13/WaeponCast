using System;

public class Health 
{
     private int _maxValue = 100;
     private float _currentValue;

    public event Action Hit;
    public event Action Healed;

    public float CurrentHealth => _currentValue;
    public int MaxValue => _maxValue;

    public void Initialize()
    {
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
