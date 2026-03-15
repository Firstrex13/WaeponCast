using UnityEngine;

public class DamageApplayerAtPosition : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Transform _damagePosition;
    [SerializeField] private int _damageAmount;

    public void ApplyDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(_damagePosition.transform.position, _radius, _mask, QueryTriggerInteraction.Collide);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out Player player))
                {
                    IDamageable damageable = player.GetComponent<Health>();
                    damageable.TakeDamage(_damageAmount);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_damagePosition.position, _radius);
    }
}
