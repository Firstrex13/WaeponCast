using UnityEngine;

public class DamageAtArea : MonoBehaviour
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private float  _radious;
    [SerializeField] private LayerMask _layerMask;

    public int DamageAmount => _weaponConfig.Damage;


    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radious, _layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(DamageAmount);
                Destroy(gameObject);

            }
        }

        if (other.TryGetComponent<Wall>(out _))
        {
            Destroy(gameObject);
        }
    }
}
