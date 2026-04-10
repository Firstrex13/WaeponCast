using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyHealth Health;
    [SerializeField] private Collider _collider;
    [SerializeField] private AIEnemy _aIEnemy;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private int _coinDropChance = 20;

    private Coroutine _dieMessage;

    public event Action<Enemy> CoinDropped;

    private void Start()
    {
        Health.Died += DieWithDelay; ;
    }

    private void OnDestroy()
    {
        Health.Died -= DieWithDelay;
    }
    public void MakeEnable()
    {
        _collider.enabled = true;
        _aIEnemy.MakeEnable();
        enabled = true;
    }

    private void MakeDisable()
    {
        _collider.enabled = false;
        _aIEnemy.MakeDisable();
        enabled = false;
    }

    private void DieWithDelay()
    {
        MakeDisable();

        if (_dieMessage != null)
        {
            StopCoroutine(_dieMessage);
        }

        _dieMessage = StartCoroutine(SendWithDelay());
    }

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(1.5f);

        yield return delay;
        Instantiate(_dieEffect, transform.position, Quaternion.identity);

        int randomNumber = UnityEngine.Random.Range(0, 100);

        gameObject.SetActive(false);

        if (randomNumber < _coinDropChance)
        {
            CoinDropped?.Invoke(this);
        }
    }
}
