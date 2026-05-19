using UnityEngine;
using Zenject;

public class CollisionDetector : Collision
{
    [SerializeField] private WeaponConfig _weaponConfig;

    public int DamageAmount => _weaponConfig.Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(DamageAmount + Force);
            Destroy(gameObject);
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Destroy(gameObject);
        }
    }
}
