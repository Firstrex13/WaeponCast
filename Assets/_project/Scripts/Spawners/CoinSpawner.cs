using System;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private Coin _coin;

    public event Action CoinCreated;

    private void OnEnable()
    {
        _enemiesSpawner.CoinDropped += CreateCoin;
    }

    private void OnDisable()
    {
        _enemiesSpawner.CoinDropped -= CreateCoin;
    }

    private void CreateCoin(Vector3 position)
    {
        Instantiate(_coin, position, Quaternion.Euler(90,0,0));
        CoinCreated?.Invoke();
    }
}
