using UnityEngine;

public class CollisionAttacker : MonoBehaviour
{
    private int _collidedDamage = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            health.TakeDamage(_collidedDamage);                          
        }
    }
}
