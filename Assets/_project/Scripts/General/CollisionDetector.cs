using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 40;

    public event Action Collided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(_damageAmount);
            Collided?.Invoke();
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Collided?.Invoke();
        }
    }
}
