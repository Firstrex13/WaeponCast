using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : MonoBehaviour
{
    [Serializable]
    public class Wave
    {
        [SerializeField] private ObjectPooller _objectPooller;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _objectsPerWave;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private int _waveInterval;

        public ObjectPooller ObjectPooller => _objectPooller;
        public float SpawnInterval => _spawnInterval;
        public int ObjectsPerWave => _objectsPerWave;
        public int EnemiesCount => _enemiesCount;
        public int WaveInterval => _waveInterval;

        public void IncreaseCount()
        {
            _enemiesCount++;
        }

        public void ResetCount()
        {
            _enemiesCount = 0;
        }
    }

    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPositions;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private int _waveNumber;
    [SerializeField] private int _enemyCount;

    private Coroutine _spawnCoroutine;

    public event Action<Vector3> CoinDropped;
    public event Action AllEnemiesDefeated;
    public event Action<int> WaveChanged;

    public int WaveNumber => _waveNumber;

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

    private IEnumerator Create()
    {
        WaitForSeconds spawnEnemyDelay = new WaitForSeconds(_waves[_waveNumber].SpawnInterval);
        WaitForSeconds waveLaunchDelay = new WaitForSeconds(_waves[_waveNumber + 1].WaveInterval);


        while (_player != null && _waveNumber < _waves.Count)
        {
            if (_waves[_waveNumber].EnemiesCount >= _waves[_waveNumber].ObjectsPerWave)
            {
                if (_waveNumber < _waves.Count - 1)
                {
                    yield return waveLaunchDelay;
                    _waveNumber++;
                    WaveChanged?.Invoke(_waveNumber + 1);
                    _waves[_waveNumber].ResetCount();
                }

                if (_waves[_waveNumber].EnemiesCount >= _waves[_waveNumber].ObjectsPerWave)
                {
                    Debug.Log("Spawn finished");                 
                    StopCoroutine(_spawnCoroutine);
                    _spawnCoroutine = null;   
                    yield return null;
                }
            }

            int randomPoint = UnityEngine.Random.Range(0, _spawnPositions.Length);

            GameObject pooledObject = _waves[_waveNumber].ObjectPooller.GetPooledObject();
            Enemy enemy = pooledObject.GetComponent<Enemy>();
            enemy.transform.position = _spawnPositions[randomPoint].position;
            transform.rotation = Quaternion.identity;
            enemy.MakeEnable();
            AIEnemy ai = enemy.GetComponent<AIEnemy>();
            enemy.gameObject.SetActive(true);
            _enemyCount++;
            enemy.CoinDropped += SandDropCoinMessage;
            enemy.Died += DecreaseEnemyCount;
            ai.Initialize(_player);
            _waves[_waveNumber].IncreaseCount();
            yield return spawnEnemyDelay;
        }
    }

    private void SandDropCoinMessage(Enemy enemy)
    {
        CoinDropped?.Invoke(enemy.transform.position + enemy.transform.up);
        enemy.CoinDropped -= SandDropCoinMessage;
    }

    private void DecreaseEnemyCount(Enemy enemy)
    {
        _enemyCount--;

        if (_enemyCount <= 0 && WaveNumber == _waves.Count - 1)
        {
            AllEnemiesDefeated?.Invoke(); ;
        }
        enemy.CoinDropped -= DecreaseEnemyCount;
    }
}
