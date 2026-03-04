using UnityEngine;

public class HealthViewBasic : MonoBehaviour
{
    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
    }

    protected Health Health => _health;

    private void OnEnable()
    {
        _health.Hit += UpdateValue;
        _health.Healed += UpdateValue;
    }

    private void OnDisable()
    {
        _health.Hit -= UpdateValue;
        _health.Healed -= UpdateValue;
    }

    public virtual void UpdateValue() { }
}
