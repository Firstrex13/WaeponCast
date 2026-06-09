using UnityEngine;

public class UnitChecker : MonoBehaviour
{
    [SerializeField] private PlayerController _mover;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;

    private Enemy _nearestEnemy;
    private Collider[] _enemies;

    public Enemy NearestEnemy => _nearestEnemy;
    public Collider[] Enemies => _enemies;

    private void Update()
    {
        FindNearestUnit();
    }
    public Enemy FindNearestUnit()
    {
        float minDistance = float.MaxValue;

        _enemies = Physics.OverlapSphere(transform.position, _radius, _mask, QueryTriggerInteraction.Collide);

        if (_enemies.Length > 0)
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                float distanceSquared = Vector3.SqrMagnitude(_enemies[i].transform.position - transform.position);

                if (distanceSquared < minDistance)
                {
                    if (_enemies[i].TryGetComponent<Enemy>(out var currentUnit))
                    {
                        minDistance = distanceSquared;

                        if (_nearestEnemy != currentUnit)
                        {
                            _nearestEnemy = currentUnit;
                        }
                    }
                }
            }
            return _nearestEnemy;
        }
        else
        {
            return _nearestEnemy = null;
        }

    }
}
