using UnityEngine;

public class CollisionAttacker : MonoBehaviour
{
    private int _collidedDamage = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Health health = player.GetComponent<Health>();
            health.TakeDamage(_collidedDamage);                          
        }
    }
}
