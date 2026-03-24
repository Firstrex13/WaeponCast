using System;
using UnityEngine;

public class Bar : MonoBehaviour, IBar
{
    protected int MaxValue;
    protected float CurrentValue;

    public float Current => CurrentValue;
    public int Max => MaxValue;

    public event Action Hit;

    public virtual void OnHit()
    {
        Hit?.Invoke();
    }
}
