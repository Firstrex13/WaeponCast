using UnityEngine;

public class Thrower : BaseSpawner<Knife>
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private int _throwSpeed;

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
        knife.gameObject.SetActive(true);
    }

    protected override void OnReturnToPool(Knife knife)
    {
        base.OnReturnToPool(knife);
        knife.Destroyed -= OnReturnToPool;
    }
}
