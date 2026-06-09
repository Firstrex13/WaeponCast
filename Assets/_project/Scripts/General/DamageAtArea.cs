using UnityEngine;

public class DamageAtArea : Collision
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private float  _radious;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _impactParticle;

    public int DamageAmount => _weaponConfig.Damage;

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radious, _layerMask, QueryTriggerInteraction.Collide);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(DamageAmount + Force);
                Instantiate(_impactParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            Instantiate(_impactParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Instantiate(_impactParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
