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

        public ObjectPooller ObjectPooller => _objectPooller;
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

    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private ParticleSystem _dieEffect;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private int _waveNumber;

    private Coroutine _spawnCoroutine;

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
        WaitForSeconds delay = new WaitForSeconds(_waves[_waveNumber].SpawnInterval);

        while (_player != null)
        {
            if (_waves[_waveNumber].EnemiesCount >= _waves[_waveNumber].ObjectsPerWave)
            {
                _waves[_waveNumber].ResetCount();

                _waveNumber++;

                if (_waveNumber >= _waves.Count)
                {
                    _waveNumber = 0;
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
            ai.Initialize(_player);
            _waves[_waveNumber].IncreaseCount();
            yield return delay;
        }
    }
}
