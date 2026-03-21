using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : BaseSpawner<Enemy>
{
    [Serializable]
    public class Wave
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _objectsPerWave;
        [SerializeField] private int _enemiesCount;

        public Enemy Enemy => _enemy;
        public float SpawnInterval => _spawnInterval;
        public int ObjectsPerWave => _objectsPerWave;
        public int EnemiesCount => _enemiesCount;

        public void IncreaseCount()
        {
            _enemiesCount++;
        }

        public void ResetCount()
        {
            _enemiesCount = 0;
        }
    }

    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private ParticleSystem _dieEffect;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private int _waveNumber;

    private int _poolCapacity = 5;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        //   Pool = new ObjectPool<Enemy>(_enemy, _poolCapacity);
    }

    private void Start()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(Create());
    }

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    protected override void OnReturnToPool(Enemy enemy)
    {
        base.OnReturnToPool(enemy);
        Instantiate(_dieEffect, enemy.transform.position, Quaternion.identity);
        enemy.Died -= OnReturnToPool;
    }

    private IEnumerator Create()
    {
        WaitForSeconds delay = new WaitForSeconds(_waves[_waveNumber].SpawnInterval);

        while (_player != null)
        {
            if (_waves[_waveNumber].EnemiesCount >= _waves[_waveNumber].ObjectsPerWave)
            {
                _waves[_waveNumber].ResetCount();

                _waveNumber++;

                if(_waveNumber >= _waves.Count)
                {
                    _waveNumber = 0;
                }
            }

            int randomPoint = UnityEngine.Random.Range(0, _spawnPositions.Length);
            //  Enemy enemy = Pool.GetFromPool();
            Enemy enemy = Instantiate(_waves[_waveNumber].Enemy, _spawnPositions[randomPoint].position, Quaternion.identity);
            enemy.MakeEnable();
            // enemy.Died += OnReturnToPool;
            //  enemy.transform.position = _spawnPositions[randomPoint].position;
            AIEnemy ai = enemy.GetComponent<AIEnemy>();
            enemy.gameObject.SetActive(true);
            ai.Initialize(_player);
            _waves[_waveNumber].IncreaseCount();
            yield return delay;
        }
    }
}
