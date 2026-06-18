using System;
using UnityEngine;

public class BarComponent : MonoBehaviour, IBar
{
    [SerializeField] protected float InvulnerableTime;

    protected int MaxValue;
    protected float CurrentValue;
    protected float Timer;

    public float Current => CurrentValue;
    public int Max => MaxValue;

    public event Action Hit;
    public event Action Died;

    public virtual void OnHit()
    {
        Hit?.Invoke();
    }

    public virtual void OnDied()
    {
        Died?.Invoke();
    }
}
