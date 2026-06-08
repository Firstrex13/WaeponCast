using UnityEngine;

public class CollisionDamage : Collision
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private GameObject _impactParticle;

    public int DamageAmount => _weaponConfig.Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(DamageAmount + Force);
            Instantiate(_impactParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Destroy(gameObject);
        }
    }
}
