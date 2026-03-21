using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] protected float _currentValue;
    [SerializeField] protected int _maxValue;

    public float CurrentValue => _currentValue;
    public int MaxValue => _maxValue;
}
