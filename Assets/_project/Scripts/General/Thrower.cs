using System;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : BaseSpawner<Knife>
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private int _throwSpeed;
    [SerializeField] private UnitChecker _unitChecker;

    private List<Knife> _pool;
    private int _poolCapacity = 10;

    //private void Awake()
    //{
    //    Pool = new ObjectPool<Knife>(_knife, _poolCapacity);
    //}

    //private void Start()
    //{
    //    CreatePool();
    //}

    public void ThrowWeapon()
    {
        if (_unitChecker.NearestEnemy == null)
        {
            return;
        }


       // knife.Destroyed += OnReturnToPool;
        Knife knife = Instantiate(_knife, _spawnPosition.position, Quaternion.identity);
        knife.Initialize(_spawnPosition.position, _spawnPosition.forward);
        knife.gameObject.SetActive(true);
        knife.GetComponent<Rigidbody>().AddForce(_spawnPosition.transform.forward * _throwSpeed, ForceMode.VelocityChange);
    }

    //protected override void OnReturnToPool(Knife knife)
    //{
    //    base.OnReturnToPool(knife);

    //    knife.Destroyed -= OnReturnToPool;
    //}

    //private void CreatePool()
    //{
    //    _pool = new List<Knife>();

    //    for (int i = 0; i < _poolCapacity; i++)
    //    {
    //        CreateNewObject();
    //    }
    //}

    //private Knife CreateNewObject()
    //{
    //    Knife knife = Instantiate(_knife, _spawnPosition.position, Quaternion.identity);
    //    knife.gameObject.SetActive(false);
    //    _pool.Add(knife);
    //    return knife;
    //}

    //public Knife GetPooledObject()
    //{
    //    foreach (var item in _pool)
    //    {
    //        if (!item.gameObject.activeSelf)
    //        {
    //            return item;
    //        }
    //    }

    //    return CreateNewObject();
    //}
}
