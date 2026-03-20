using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Mana : MonoBehaviour
{
    [SerializeField] private float _currentValue;

    [SerializeField] private int _maxValue;
    [SerializeField] private int _speedRecovery;

    public float CurrentMana => _currentValue;
    public int MaxValue => _maxValue;

    private void OnEnable()
    {
        _currentValue = _maxValue;
    }

    private void Update()
    {
        _currentValue += _speedRecovery * Time.deltaTime;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
    }

    public void Reduce(float cost)
    {
        if (_currentValue > 0)
        {
            if (cost < 0)
            {
                cost = 0;
            }
        }

        if (cost > 0)
        {
            _currentValue -= cost;

            if (_currentValue <= 0)
            {
                _currentValue = 0;
            }
        }
    }
}
