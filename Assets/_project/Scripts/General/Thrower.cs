using System.Collections.Generic;
using UnityEngine;

public class Thrower : BaseSpawner<Knife>
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private int _throwSpeed;
    [SerializeField] private UnitChecker _unitChecker;

    private int _poolCapacity = 10;

    private void Awake()
    {
        Pool = new ObjectPool<Knife>(_knife, _poolCapacity);
    }

    public void ThrowWeapon()
    {
        if (_unitChecker.NearestEnemy == null)
        {
            return;
        }

        Knife knife = Pool.GetFromPool();
        knife.Destroyed += OnReturnToPool;
        knife.Initialize(_spawnPosition.position, _spawnPosition.forward);
        knife.GetComponent<Rigidbody>().AddForce(_spawnPosition.transform.forward * _throwSpeed, ForceMode.VelocityChange);
    }

    protected override void OnReturnToPool(Knife knife)
    {
        base.OnReturnToPool(knife);
        knife.Destroyed -= OnReturnToPool;
    }
}
