using UnityEngine;

public class CollisionAttacker : MonoBehaviour
{
    [SerializeField] private int _collidedDamage = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(_collidedDamage);                          
        }     
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(_collidedDamage);
        }
    }
}
