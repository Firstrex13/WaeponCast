using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : BaseSpawner<Dragon>
{
    [SerializeField] private Dragon _dragon;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPositions;

    private int _poolCapacity = 10;
    private void Awake()
    {
        Pool = new ObjectPool<Dragon>(_dragon, _poolCapacity);
    }

    private void Start()
    {
        StartCoroutine(Create());
    }

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    protected override void OnReturnToPool(Dragon dragon)
    {
        base.OnReturnToPool(dragon);
        dragon.Died -= OnReturnToPool;
    }

    private IEnumerator Create()
    {
        WaitForSeconds delay = new WaitForSeconds(3);

        while (enabled)
        {
            int randomPoint = Random.Range(0, _spawnPositions.Length);
            Dragon dragon = Pool.GetFromPool();
            dragon.Died += OnReturnToPool;
            dragon.transform.position = _spawnPositions[randomPoint].position;
          //  Dragon dragon = Instantiate(_dragon, _spawnPositions[randomPoint].position, Quaternion.identity, transform);
            AIEnemy ai = dragon.GetComponent<AIEnemy>();
            ai.Initialize(_player);
            yield return delay;

        }
    } 
    
}
