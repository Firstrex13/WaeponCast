using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private WeaponConfig _weaponConfig;

    public int DamageAmount => _weaponConfig.Damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(DamageAmount);
            Destroy(gameObject);
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Destroy(gameObject);
        }
    }
}
