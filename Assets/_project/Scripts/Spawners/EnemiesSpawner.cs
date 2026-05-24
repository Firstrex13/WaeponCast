using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private Enemy _bossPrefab;
    [SerializeField] private Slider _slider;

    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPositions;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private int _waveNumber;

    private Coroutine _spawnCoroutine;
    [SerializeField] private int _totalEnemiesOnLevel;

    public event Action<Vector3> CoinDropped;
    public event Action AllEnemiesDefeated;
    public event Action<int> WaveChanged;
    public event Action BossSpawned;

    public int WaveNumber => _waveNumber;
    public List<Wave> Waves => _waves;

    private void Start()
    {
        foreach (var wave in _waves)
        {
            _totalEnemiesOnLevel += wave.ObjectsPerWave;
        }

        _totalEnemiesOnLevel++;

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
                    StopCoroutine(_spawnCoroutine);
                    _spawnCoroutine = null;
                    Enemy boss = Instantiate(_bossPrefab, Vector3.zero, Quaternion.identity);
                    BossHealthView bossHealth = boss.GetComponent<BossHealthView>();
                    AIEnemyBoss aiBoss = boss.GetComponent<AIEnemyBoss>();
                    aiBoss.Initialize(_player);
                    bossHealth.Initialize(_slider);
                    BossSpawned?.Invoke();
                    boss.Died += DecreaseEnemyCount;
                    yield return null;
                }
            }

            int randomPoint = UnityEngine.Random.Range(0, _spawnPositions.Length);

            GameObject pooledObject = _waves[_waveNumber].ObjectPooller.GetPooledObject();
            EnemyUnit enemy = pooledObject.GetComponent<EnemyUnit>();
            enemy.transform.position = _spawnPositions[randomPoint].position;
            transform.rotation = Quaternion.identity;
            enemy.MakeEnable();
            AIEnemyUnit ai = enemy.GetComponent<AIEnemyUnit>();
            enemy.gameObject.SetActive(true);
            enemy.CoinDropped += SandDropCoinMessage;
            enemy.Died += DecreaseEnemyCount;
            ai.Initialize(_player);
            _waves[_waveNumber].IncreaseCount();
            yield return spawnEnemyDelay;
        }
    }

    private void SandDropCoinMessage(EnemyUnit enemy)
    {
        CoinDropped?.Invoke(enemy.transform.position + enemy.transform.up);
        enemy.CoinDropped -= SandDropCoinMessage;
    }

    private void DecreaseEnemyCount(Enemy enemy)
    {
        _totalEnemiesOnLevel--;

        if (WaveNumber == _waves.Count - 1 && _totalEnemiesOnLevel <= 0)
        {
            AllEnemiesDefeated?.Invoke(); ;
        }

        enemy.Died -= DecreaseEnemyCount;
    }
}
